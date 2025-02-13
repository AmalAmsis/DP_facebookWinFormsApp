using System;
using System.IO;

namespace BasicFacebookFeatures.Observers
{
    public class GameLogger : IGameObserver
    {
        private readonly string r_logFilePath = "GameLog.txt";

        public void Update(int i_correctAnswers, int i_wrongAnswers, int i_remainingPhotos)
        {
            string logMessage = $"{DateTime.Now}: Correct={i_correctAnswers}, Wrong={i_wrongAnswers}, Remaining={i_remainingPhotos}";

            try
            {
                File.AppendAllText(r_logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}
