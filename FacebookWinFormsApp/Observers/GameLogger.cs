using System;
using System.IO;

namespace BasicFacebookFeatures.Observers
{
    public class GameLogger : IGameObserver
    {
        private readonly string logFilePath = "GameLog.txt";

        public void Update(int correctAnswers, int wrongAnswers, int remainingPhotos)
        {
            string logMessage = $"{DateTime.Now}: Correct={correctAnswers}, Wrong={wrongAnswers}, Remaining={remainingPhotos}";

            try
            {
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}
