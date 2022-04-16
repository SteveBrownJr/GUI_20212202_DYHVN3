using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Models
{
    public interface IEntity
    {
        public int ActualHp { get; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        bool standing_on_the_ground { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool MoveLeft { get; set; }
        public bool MoveRight { get; set; }
        public bool Jump { get; set; }
        public bool Chrouch { get; set; }
        public void MeleeAttack();
        public void RangedAttack();
    }
}
