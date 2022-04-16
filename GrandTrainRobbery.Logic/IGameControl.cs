using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Logic
{
    public enum Movements {LEFT,RIGHT,UP,DOWN }
    public interface IGameControl
    {
        public void TimeStep(List<Movements> Buttons);
    }
}
