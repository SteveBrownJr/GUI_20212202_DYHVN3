using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Models
{
    public class Bullet : IEntity
    {
        public int ActualHp => 0;
        public IEntity Sender { get; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }

        public bool standing_on_the_ground => false;

        public int X { get; set; }
        public int Y { get; set; }
        public bool RangedAttacking { get; set; }
        public bool MeleeAttacking { get; set; }
        public bool MoveLeft { get; set; }
        public bool MoveRight { get; set; }
        public bool Jump { get; set; }
        public bool Chrouch { get; set; }
        public string Texture { get; }
        public void MeleeAttack()
        {
            
        }

        public void RangedAttack()
        {
            
        }
        public Bullet(string texture, int x, int y,bool moveLeft, bool moveright,IEntity sender)
        {
            Sender = sender;
            Texture = texture;
            X = x;
            Y = y;
            MoveLeft = moveLeft;
            MoveRight = moveright;
        }
    }
}
