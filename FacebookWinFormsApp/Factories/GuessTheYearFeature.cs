using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Adapters;

namespace BasicFacebookFeatures.Features
{
    public class GuessTheYearFeature : FacebookFeature
    {
        private FormGuessTheYear m_GuessTheYearForm;

        public GuessTheYearFeature(Form i_MainForm, User i_FacebookUser)
            : base(i_MainForm, i_FacebookUser)
        {
            
        }

        public override void Show()
        {
            HideMainForm();

            IGuessTheYearGame game = new GuessTheYearGameAdapter(this.FacebookUser);
            m_GuessTheYearForm = new FormGuessTheYear()
            {
                MainForm = this.MainForm
            };

            m_GuessTheYearForm.LoadGame(game);
            m_GuessTheYearForm.ShowDialog();
        }
    }
} 