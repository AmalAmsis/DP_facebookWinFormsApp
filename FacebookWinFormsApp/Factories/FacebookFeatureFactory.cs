using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Features
{
    public enum eFeatureType
    {
        GuessTheYear,
        ProfileAnalyzer
    }

    public static class FacebookFeatureFactory
    {
        public static FacebookFeature CreateFeature(eFeatureType i_FeatureType, Form i_MainForm, User i_LoggedInUser)
        {
            FacebookFeature feature = null;

            switch (i_FeatureType)
            {
                case eFeatureType.GuessTheYear:
                    feature = new GuessTheYearFeature(i_MainForm, i_LoggedInUser);
                    break;
                case eFeatureType.ProfileAnalyzer:
                    feature = new ProfileAnalyzerFeature(i_MainForm, i_LoggedInUser);
                    break;
            }

            return feature;
        }
    }
} 