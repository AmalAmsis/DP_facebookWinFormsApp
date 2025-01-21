using FacebookWrapper.ObjectModel;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public abstract class FacebookFeature
    {
        public Form MainForm { get; set; }

        public abstract void Show();
        
        protected void HideMainForm()
        {
            MainForm?.Hide();
        }
    }
} 