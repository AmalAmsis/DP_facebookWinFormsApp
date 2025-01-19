using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Features
{
    public class ProfileAnalyzerFeature : IFacebookFeature
    {
        private readonly Form r_MainForm;
        private FormProfileAnalyzer m_ProfileAnalyzerForm;

        private readonly ProfileAnalyzerFacade r_profileAnalyzerFacade;

        public ProfileAnalyzerFeature(Form i_MainForm, User i_LoggedInUser)
        {
            r_MainForm = i_MainForm;
            r_profileAnalyzerFacade = new ProfileAnalyzerFacade(i_LoggedInUser);
        }

        public void Show()
        {
            r_MainForm.Hide();  
            initializeAndShowForm();
        }

        private void initializeAndShowForm()
        {
            m_ProfileAnalyzerForm = new FormProfileAnalyzer(r_profileAnalyzerFacade)
            {
                MainForm = r_MainForm
            };

            m_ProfileAnalyzerForm.ShowDialog();
        }
    }
} 