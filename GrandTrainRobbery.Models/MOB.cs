using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Models
{
    public class MOB 
    {
        string name;
        int id;
        int x;
        int y;
        string texturePath;
        string description;
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string TexturePath { get => texturePath; set => texturePath = value; }
        public bool standing_on_the_ground { get => M.Floor == this.Y; }
        Map M;
        public MOB(Map m, string _name, int _id, string _description, int _x, int _y, string _texturePath)
        {
            this.M = m;
            Name = _name;
            Id = _id;
            Description = _description;
            X = _x;
            Y = _y;
            TexturePath = _texturePath;
        }

        public void MeleeAttack()
        {
            throw new NotImplementedException();
        }

        public void RangedAttack()
        {
            throw new NotImplementedException();
        }
    }
}
