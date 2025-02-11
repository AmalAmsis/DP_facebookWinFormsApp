using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Observers
{
    public class GameStatsDisplay : IGameObserver
    {
        private Label correctLabel, wrongLabel, remainingLabel;

        public GameStatsDisplay(Label i_Correct, Label i_Wrong, Label i_Remaining)
        {
            correctLabel = i_Correct;
            wrongLabel = i_Wrong;
            remainingLabel = i_Remaining;
        }

        public void Update(int correctAnswers, int wrongAnswers, int remainingPhotos)
        {
            correctLabel.Invoke(new Action(() =>
                correctLabel.Text = $"{correctAnswers}"
            ));
            wrongLabel.Invoke(new Action(() =>
                wrongLabel.Text = $"{wrongAnswers}"
            ));
            remainingLabel.Invoke(new Action(() =>
                remainingLabel.Text = $"{remainingPhotos}"
            ));
        }
    }
}
