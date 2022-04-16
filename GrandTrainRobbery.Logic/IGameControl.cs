using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Logic
{
    public interface IGameControl
    {
        public void PlayerMoveLeft();
        public void PlayerMoveRight();
        public void PlayerJump();
        public void PlayerCrouch();
        public void PlayerMelee();
        public void PlayerAttack();
    }
}
