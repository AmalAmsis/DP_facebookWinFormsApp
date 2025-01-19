using System.Windows.Forms;
using FacebookWrapper;

namespace BasicFacebookFeatures.Features
{
    public class GuessTheYearFeature : IFacebookFeature
    {
        private readonly Form r_MainForm;
        private readonly LoginResult r_LoginResult;
        private FormGuessTheYear m_GuessTheYearForm;

        public GuessTheYearFeature(Form i_MainForm, LoginResult i_LoginResult)
        {
            r_MainForm = i_MainForm;
            r_LoginResult = i_LoginResult;
        }

        public void Show()
        {
            r_MainForm.Hide();
            initializeAndShowForm();
        }

        private void initializeAndShowForm()
        {
            m_GuessTheYearForm = new FormGuessTheYear
            {
                MainForm = r_MainForm,
                LoginResult = r_LoginResult
            };

            m_GuessTheYearForm.ShowDialog();
        }
    }
} 