using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Features
{
    public class ProfileAnalyzerFeature : FacebookFeature
    {
        private FormProfileAnalyzer m_ProfileAnalyzerForm;

        public override void Show()
        {
            HideMainForm();

            m_ProfileAnalyzerForm = new FormProfileAnalyzer(new ProfileAnalyzerFacade())
            {
                MainForm = this.MainForm
            };

            m_ProfileAnalyzerForm.ShowDialog();
        }
    }
} 