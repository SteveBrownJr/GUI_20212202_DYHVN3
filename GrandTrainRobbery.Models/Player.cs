using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrandTrainRobbery.Models
{
    public class Player : IEntity
    {
        string name;
        int id;
        int x;
        int y;
        string texturePath;
        string description;
        Map m;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string TexturePath { get => texturePath; set => texturePath = value; }
        public bool standing_on_the_ground { get => m.Floor == this.Y; }

        public Player(Map m, string _name, int _id, string _description, int _x, int _y, string _texturePath)
        {
            this.m = m;
            Name = _name;
            Id = _id;
            Description = _description;
            X = _x;
            Y = _y;
            TexturePath = _texturePath;
        }
        public Player(XElement PlayerXElement)
        {
            m = null;
            Name = PlayerXElement.Element("Name").Value;
            id = -1;
            description = null;
            x = 0;
            y = 0;
            texturePath = "none";
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
