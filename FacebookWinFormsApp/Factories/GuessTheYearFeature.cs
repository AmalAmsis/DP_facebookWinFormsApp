using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Features
{
    public class GuessTheYearFeature : FacebookFeature
    {
        private FormGuessTheYear m_GuessTheYearForm;

        public override void Show()
        {
            HideMainForm();

            m_GuessTheYearForm = new FormGuessTheYear(
                                 new GuessTheYearGame(
                                     FacebookManager.Instance.LoggedInUser))
            {
                MainForm = this.MainForm
            };

            m_GuessTheYearForm.ShowDialog();
        }
    }
} 