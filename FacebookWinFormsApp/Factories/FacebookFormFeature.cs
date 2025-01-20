using FacebookWrapper.ObjectModel;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public abstract class FacebookFeature
    {
        public Form MainForm { get; private set; }
        public User FacebookUser { get; private set; }

        protected FacebookFeature(Form i_MainForm, User i_FacebookUser)
        {
            MainForm = i_MainForm;
            FacebookUser = i_FacebookUser;
        }

        public abstract void Show();
        
        protected void HideMainForm()
        {
            MainForm?.Hide();
        }
    }
} 