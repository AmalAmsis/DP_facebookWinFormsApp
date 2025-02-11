using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Observers
{
    public interface IGameObserver
    {
        void Update(int correctAnswers, int wrongAnswers, int remainingPhotos);
    }
}
