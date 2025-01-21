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
        public static FacebookFeature CreateFeature(eFeatureType i_FeatureType, Form i_MainForm)
        {
            FacebookFeature feature = null;

            switch (i_FeatureType)
            {
                case eFeatureType.GuessTheYear:
                    feature = new GuessTheYearFeature()
                    {
                        MainForm = i_MainForm
                    };
                    break;
                case eFeatureType.ProfileAnalyzer:
                    feature = new ProfileAnalyzerFeature()
                    {
                        MainForm = i_MainForm
                    };
                    break;
            }

            return feature;
        }
    }
} 