using BasicFacebookFeatures.Observers;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicFacebookFeatures
{
    public class GuessTheYearGame
    {
        private readonly User m_LoggedInUser;

        private readonly FacebookObjectCollection<Photo> r_PhotoCollection = new FacebookObjectCollection<Photo>();
        private readonly Random r_RandomGenerator = new Random();
        private int m_CorrectAnswerIndex;
        private int m_CorrectAnswers = 0;
        private int m_WrongAnswers = 0;
        private Photo m_CurrentPhoto;
        private List<IGameObserver> observers = new List<IGameObserver>();

        public GuessTheYearGame(User i_LoggedInUser)
        {
            m_LoggedInUser = i_LoggedInUser;
            LoadUserPhotos();
        }

        //public int CorrectAnswers { get; private set; }
        //public int WrongAnswers { get; private set; }
        //public int RemainingPhotos { get; private set; }
        public int RemainingPhotos
        {
            get
            {
                return r_PhotoCollection.Count;
            }
            
        }

        public int CorrectAnswers
        {
            get 
            { 
                return m_CorrectAnswers; 
            }
        }

        public int WrongAnswers
        {
            get 
            {
                return m_WrongAnswers; 
            }
        }

        public int CorrectAnswerIndex
        {
            get
            {
                return m_CorrectAnswerIndex;
            }
        }

        public Photo CurrentPhoto
        {
            get
            {
                return m_CurrentPhoto;
            }
        }

        public void AddObserver(IGameObserver observer)
        {
            observers.Add(observer);
        }

        private void notifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(CorrectAnswers, WrongAnswers, RemainingPhotos);
            }
        }

        public bool LoadUserPhotos()
        {
            if (m_LoggedInUser?.Albums == null || !m_LoggedInUser.Albums.Any())
            {
                return false;
            }

            foreach (Album album in m_LoggedInUser.Albums)
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
                m_CorrectAnswers++;
            else
                m_WrongAnswers++;

            notifyObservers(); 

            return isCorrect;
        }


        public bool DisplayNextQuestion(Action<string> onPhotoWithoutDate)
        {
            m_CurrentPhoto = GetNextPhoto();
            if (m_CurrentPhoto == null)
            {
                return false;
            }

            if (!m_CurrentPhoto.CreatedTime.HasValue)
            {
                onPhotoWithoutDate?.Invoke("Photo has no creation date. Skipping...");
                return DisplayNextQuestion(onPhotoWithoutDate);
            }

            notifyObservers(); 

            return true;
        }


        public List<int> GetCurrentAnswerOptions()
        {
            if (m_CurrentPhoto?.CreatedTime == null)
            {
                return null;
            }

            return GenerateAnswerOptions(m_CurrentPhoto.CreatedTime.Value.Year);
        }

        //public void HandleAnswer(int i_SelectedAnswerIndex, Action onAnswerProcessed)
        //{
        //    bool isCorrect = CheckAnswer(i_SelectedAnswerIndex);
        //    onAnswerProcessed?.Invoke();
        //}
        public void HandleAnswer(int i_SelectedAnswerIndex, Action onAnswerProcessed)
        {
            bool isCorrect = i_SelectedAnswerIndex == m_CorrectAnswerIndex;

            if (isCorrect)
                m_CorrectAnswers++;
            else
                m_WrongAnswers++;

            notifyObservers(); 

            onAnswerProcessed?.Invoke(); 
        }



        public string GetGameSummary()
        {
            return $"Congratulations! You've completed the challenge.\n" +
                   $"Correct Answers: {CorrectAnswers}\n" +
                   $"Wrong Answers: {WrongAnswers}";
        }
    }
} 