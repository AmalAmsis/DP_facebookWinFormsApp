using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Observers
{
    public interface IGameObserver
    {
        void Update(int i_correctAnswers, int i_wrongAnswers, int i_remainingPhotos);
    }
}
