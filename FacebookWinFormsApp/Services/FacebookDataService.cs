using FacebookWrapper.ObjectModel;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Services
{
    internal class FacebookDataService
    {
        private readonly User r_LoggedInUser;

        public FacebookDataService(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
        }

        public async Task<UserData> GetUserData()
        {
            return new UserData
            {
                BasicInfo = await GetBasicInfo(),
                SocialInfo = await GetSocialInfo(),
                ActivityInfo = await GetActivityInfo()
            };
        }

        private async Task<BasicInfo> GetBasicInfo()
        {
            return new BasicInfo
            {
                Name = r_LoggedInUser.Name,
                ProfilePicture = r_LoggedInUser.PictureNormalURL,
                Birthday = r_LoggedInUser.Birthday,
                Hometown = r_LoggedInUser.Hometown?.Name
            };
        }

        private async Task<SocialInfo> GetSocialInfo()
        {
            return new SocialInfo
            {
                Friends = r_LoggedInUser.Friends,
                Languages = r_LoggedInUser.Languages,
                LikedPages = r_LoggedInUser.LikedPages
            };
        }

        private async Task<ActivityInfo> GetActivityInfo()
        {
            return new ActivityInfo
            {
                Posts = r_LoggedInUser.Posts,
                Albums = r_LoggedInUser.Albums,
                Events = r_LoggedInUser.Events
            };
        }
    }

    public class UserData
    {
        public BasicInfo BasicInfo { get; set; }
        public SocialInfo SocialInfo { get; set; }
        public ActivityInfo ActivityInfo { get; set; }
    }

    public class BasicInfo
    {
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public string Birthday { get; set; }
        public string Hometown { get; set; }
    }

    public class SocialInfo
    {
        public FacebookObjectCollection<User> Friends { get; set; }
        public FacebookObjectCollection<Page> Languages { get; set; }
        public FacebookObjectCollection<Page> LikedPages { get; set; }
    }

    public class ActivityInfo
    {
        public FacebookObjectCollection<Post> Posts { get; set; }
        public FacebookObjectCollection<Album> Albums { get; set; }
        public FacebookObjectCollection<Event> Events { get; set; }
    }
} 