using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Features
{
    public class ProfileAnalyzerFeature : FacebookFeature
    {
        private FormProfileAnalyzer m_ProfileAnalyzerForm;

        public ProfileAnalyzerFeature(Form i_MainForm, User i_FacebookUser)
            : base(i_MainForm, i_FacebookUser)
        {
            
        }

        public override void Show()
        {
            HideMainForm();

            m_ProfileAnalyzerForm = new FormProfileAnalyzer(new ProfileAnalyzerFacade(this.FacebookUser))
            {
                MainForm = this.MainForm
            };

            m_ProfileAnalyzerForm.ShowDialog();
        }
    }
} 