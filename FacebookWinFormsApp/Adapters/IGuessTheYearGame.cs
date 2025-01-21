using System.Collections.Generic;

namespace BasicFacebookFeatures.Adapters
{
    public interface IGuessTheYearGame : IFacebookGame
    {
        PhotoInfo GetCurrentPhoto();
        List<int> GetAnswerOptions();
        bool CheckAnswer(int i_SelectedAnswerIndex);
        PhotoInfo GetNextPhoto();
        int GetCorrectAnswerIndex();
    }
} 