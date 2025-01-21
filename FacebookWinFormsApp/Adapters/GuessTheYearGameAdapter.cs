using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures;

namespace BasicFacebookFeatures.Adapters
{
    public class GuessTheYearGameAdapter : IGuessTheYearGame
    {
        private readonly GuessTheYearGame r_Game;
        private readonly User r_FacebookUser;

        public GuessTheYearGameAdapter(User i_LoggedInUser)
        {
            r_Game = new GuessTheYearGame();
            r_FacebookUser = i_LoggedInUser;
        }

        public string GameName => "Guess The Year";

        public int Score => r_Game.CorrectAnswers;

        public void Start()
        {
            loadPhotosFromFacebook();
        }

        public void End()
        {
            // Cleanup if needed
        }

        public string GetGameSummary()
        {
            return r_Game.GetGameSummary();
        }

        private void loadPhotosFromFacebook()
        {
            if (r_FacebookUser?.Albums == null) return;

            foreach (Album album in r_FacebookUser.Albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    if (photo.CreatedTime.HasValue)
                    {
                        r_Game.AddPhoto(photo.PictureNormalURL, photo.CreatedTime.Value);
                    }
                }
            }
        }

        public PhotoInfo GetCurrentPhoto() => r_Game.CurrentPhoto;
        public List<int> GetAnswerOptions() => r_Game.GenerateAnswerOptions();
        public bool CheckAnswer(int i_SelectedIndex) => r_Game.CheckAnswer(i_SelectedIndex);
        public PhotoInfo GetNextPhoto() => r_Game.GetNextPhoto();
        public int GetCorrectAnswerIndex() => r_Game.CorrectAnswerIndex;
    }
} 