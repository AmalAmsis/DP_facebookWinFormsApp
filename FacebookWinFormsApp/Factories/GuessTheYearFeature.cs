using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Features
{
    public class GuessTheYearFeature : IFacebookFeature
    {
        private readonly Form r_MainForm;
        private FormGuessTheYear m_GuessTheYearForm;

        private readonly GuessTheYearGame r_GuessTheYearGame;

        public GuessTheYearFeature(Form i_MainForm, User i_LoggedInUser)
        {
            r_MainForm = i_MainForm;
            r_GuessTheYearGame = new GuessTheYearGame(i_LoggedInUser);
        }

        public void Show()
        {
            r_MainForm.Hide();
            initializeAndShowForm();
        }

        private void initializeAndShowForm()
        {
            m_GuessTheYearForm = new FormGuessTheYear(r_GuessTheYearGame)
            {
                MainForm = r_MainForm,
            };

            m_GuessTheYearForm.ShowDialog();
        }
    }
} 