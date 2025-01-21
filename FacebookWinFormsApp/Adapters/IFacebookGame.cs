namespace BasicFacebookFeatures.Adapters
{
    public interface IFacebookGame
    {
        string GameName { get; }
        int Score { get; }
        void Start();
        void End();
        string GetGameSummary();
    }
} 