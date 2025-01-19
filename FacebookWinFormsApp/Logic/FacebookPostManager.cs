using FacebookWrapper.ObjectModel;
using System;

namespace BasicFacebookFeatures
{
    public class FacebookPostManager
    {
        private const string k_ServerError = "Facebook server-side error.";
        private const string k_PostEmptyError = "Please enter your post first!";
        private const string k_PostFailedError = "Post failed.";
        private const string k_PicturePostFailedError = "Picture post failed.";
        private const string k_LoginRequiredError = "Please log in first.";
        private const string k_PictureRenderingError = "Error rendering the picture.";

        public FacebookPostManager(User i_FacebookUser)
        {
            FacebookUser = i_FacebookUser;
        }

        public User FacebookUser { get; }

        public void PostStatus(string i_PostText)
        {
            if (FacebookUser != null)
            {
                if (string.IsNullOrWhiteSpace(i_PostText))
                {
                    throw new Exception(k_PostEmptyError);
                }
                else
                {
                    try
                    {
                        Status postedStatus = FacebookUser.PostStatus(i_PostText);

                        if (postedStatus == null)
                        {
                            throw new Exception(k_PostFailedError);
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception(k_ServerError);
                    }
                }
            }
            else
            {
                throw new Exception(k_LoginRequiredError);
            }
        }

        public void PostPicture(string i_PostText, string i_PicturePath)
        {
            try
            {
                Status postedStatus = FacebookUser.PostStatus(i_PostText, i_PictureURL: i_PicturePath);

                if (postedStatus == null)
                {
                    throw new Exception(k_PicturePostFailedError);
                }
            }
            catch (Exception)
            {
                throw new Exception(k_ServerError);
            }
        }
    }
}
