using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Models
{
    public interface IEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        bool standing_on_the_ground { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public string TexturePath { get; set; }
        public void MeleeAttack();
        public void RangedAttack();
    }
}
