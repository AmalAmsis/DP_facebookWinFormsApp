using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicFacebookFeatures
{
    public class GuessTheYearGame
    {
        private readonly List<PhotoInfo> r_PhotoCollection = new List<PhotoInfo>();
        private readonly Random r_RandomGenerator = new Random();
        private int m_CorrectAnswerIndex;
        private int m_CorrectAnswers = 0;
        private int m_WrongAnswers = 0;
        private PhotoInfo m_CurrentPhoto;

        public int RemainingPhotos => r_PhotoCollection.Count;
        public int CorrectAnswers => m_CorrectAnswers;
        public int WrongAnswers => m_WrongAnswers;
        public int CorrectAnswerIndex => m_CorrectAnswerIndex;
        public PhotoInfo CurrentPhoto => m_CurrentPhoto;

        public void AddPhoto(string i_PhotoUrl, DateTime i_PhotoDate)
        {
            r_PhotoCollection.Add(new PhotoInfo(i_PhotoUrl, i_PhotoDate));
        }

        public PhotoInfo GetNextPhoto()
        {
            if (r_PhotoCollection.Count > 0)
            {
                PhotoInfo nextPhoto = r_PhotoCollection[0];
                r_PhotoCollection.RemoveAt(0);
                m_CurrentPhoto = nextPhoto;
                return nextPhoto;
            }

            return null;
        }

        public List<int> GenerateAnswerOptions()
        {
            if (m_CurrentPhoto == null) return null;

            int correctYear = m_CurrentPhoto.DateTaken.Year;
            int lowerBound = Math.Max(correctYear - 5, DateTime.MinValue.Year);
            int upperBound = Math.Min(correctYear + 5, DateTime.Now.Year);
            List<int> answerOptions = new List<int>();
            List<int> usedYears = new List<int>();

            m_CorrectAnswerIndex = r_RandomGenerator.Next(0, 4);

            for (int i = 0; i < 4; i++)
            {
                if (i == m_CorrectAnswerIndex)
                {
                    answerOptions.Add(correctYear);
                }
                else
                {
                    int randomYear;
                    do
                    {
                        randomYear = r_RandomGenerator.Next(lowerBound, upperBound + 1);
                    }
                    while (usedYears.Contains(randomYear) || randomYear == correctYear);

                    usedYears.Add(randomYear);
                    answerOptions.Add(randomYear);
                }
            }

            return answerOptions;
        }

        public bool CheckAnswer(int i_SelectedAnswerIndex)
        {
            bool isCorrect = i_SelectedAnswerIndex == m_CorrectAnswerIndex;
            
            if (isCorrect)
            {
                m_CorrectAnswers++;
            }
            else
            {
                m_WrongAnswers++;
            }

            return isCorrect;
        }

        public string GetGameSummary()
        {
            return $"Game Over!\nCorrect Answers: {CorrectAnswers}\nWrong Answers: {WrongAnswers}";
        }
    }

    public class PhotoInfo
    {
        public string ImageUrl { get; }
        public DateTime DateTaken { get; }

        public PhotoInfo(string i_ImageUrl, DateTime i_DateTaken)
        {
            ImageUrl = i_ImageUrl;
            DateTaken = i_DateTaken;
        }
    }
} 