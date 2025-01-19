using System.Windows.Forms;
using FacebookWrapper;

namespace BasicFacebookFeatures.Features
{
    public enum eFeatureType
    {
        GuessTheYear,
        ProfileAnalyzer
    }

    public class FacebookFeatureFactory
    {
        private readonly Form r_MainForm;
        private readonly LoginResult r_LoginResult;

        public FacebookFeatureFactory(Form i_MainForm, LoginResult i_LoginResult)
        {
            r_MainForm = i_MainForm;
            r_LoginResult = i_LoginResult;
        }

        public IFacebookFeature CreateFeature(eFeatureType i_FeatureType)
        {
            IFacebookFeature feature = null;

            switch (i_FeatureType)
            {
                case eFeatureType.GuessTheYear:
                    feature = new GuessTheYearFeature(r_MainForm, r_LoginResult.LoggedInUser);
                    break;
                case eFeatureType.ProfileAnalyzer:
                    feature = new ProfileAnalyzerFeature(r_MainForm, r_LoginResult.LoggedInUser);
                    break;
            }

            return feature;
        }
    }
} 