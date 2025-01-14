using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicFacebookFeatures
{
    public class GuessTheYearGame
    {
        private readonly FacebookObjectCollection<Photo> r_PhotoCollection = new FacebookObjectCollection<Photo>();
        private readonly Random r_RandomGenerator = new Random();
        private int m_CorrectAnswerIndex;
        private int m_CorrectAnswers = 0;
        private int m_WrongAnswers = 0;

        public int RemainingPhotos => r_PhotoCollection.Count;
        public int CorrectAnswers => m_CorrectAnswers;
        public int WrongAnswers => m_WrongAnswers;
        public int CorrectAnswerIndex => m_CorrectAnswerIndex;

        public bool LoadUserPhotos(User i_LoggedInUser)
        {
            if (i_LoggedInUser?.Albums == null || !i_LoggedInUser.Albums.Any())
            {
                return false;
            }

            foreach (Album album in i_LoggedInUser.Albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    r_PhotoCollection.Add(photo);
                }
            }

            return true;
        }

        public Photo GetNextPhoto()
        {
            if (r_PhotoCollection.Count > 0)
            {
                Photo nextPhoto = r_PhotoCollection[0];
                r_PhotoCollection.RemoveAt(0);
                return nextPhoto;
            }

            return null;
        }

        public List<int> GenerateAnswerOptions(int i_CorrectYear)
        {
            int lowerBound = Math.Max(i_CorrectYear - 5, DateTime.MinValue.Year);
            int upperBound = Math.Min(i_CorrectYear + 5, DateTime.Now.Year);
            List<int> answerOptions = new List<int>();
            List<int> usedYears = new List<int>();

            m_CorrectAnswerIndex = r_RandomGenerator.Next(0, 4);

            for (int i = 0; i < 4; i++)
            {
                if (i == m_CorrectAnswerIndex)
                {
                    answerOptions.Add(i_CorrectYear);
                }
                else
                {
                    int randomYear;
                    do
                    {
                        randomYear = r_RandomGenerator.Next(lowerBound, upperBound + 1);
                    }
                    while (usedYears.Contains(randomYear) || randomYear == i_CorrectYear);

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
    }
} 