using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Features
{
    public class GuessTheYearFeature : FacebookFeature
    {
        private FormGuessTheYear m_GuessTheYearForm;

        public GuessTheYearFeature(Form i_MainForm, User i_FacebookUser)
            : base(i_MainForm, i_FacebookUser)
        {
            r_AnalyzerFacade = new AnalyzerFacade(i_UserForAnalysis);
        }

        public override void Show()
        {
            HideMainForm();

            m_GuessTheYearForm = new FormGuessTheYear(new GuessTheYearGame(User))
            {
                MainForm = Form
            };

            m_GuessTheYearForm.ShowDialog();
        }
    }
} 