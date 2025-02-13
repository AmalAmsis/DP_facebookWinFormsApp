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
        private Label m_correctLabel;
        private Label m_wrongLabel;
        private Label m_remainingLabel;

        public GameStatsDisplay(Label i_Correct, Label i_Wrong, Label i_Remaining)
        {
            m_correctLabel = i_Correct;
            m_wrongLabel = i_Wrong;
            m_remainingLabel = i_Remaining;
        }

        public void Update(int i_correctAnswers, int i_wrongAnswers, int i_remainingPhotos)
        {
            m_correctLabel.Invoke(new Action(() =>
               m_correctLabel.Text = $"{i_correctAnswers}"
            ));
            m_wrongLabel.Invoke(new Action(() =>
                m_wrongLabel.Text = $"{i_wrongAnswers}"
            ));
            m_remainingLabel.Invoke(new Action(() =>
                m_remainingLabel.Text = $"{i_remainingPhotos}"
            ));
        }
    }
}
