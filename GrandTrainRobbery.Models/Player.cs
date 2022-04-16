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
        string meleeTexturePath;
        string attackTexturePath;
        string chrouchTexturePath;
        string description;
        Map m;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string TexturePath { get => texturePath;}
        public string MeleeTexturePath { get => meleeTexturePath; }
        public string AttackTexturePath { get => attackTexturePath; }
        public string ChrouchTexturePath { get => chrouchTexturePath; }
        public bool standing_on_the_ground { get => m.Floor == this.Y; }
        string IEntity.TexturePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Player(Map m, string _name, int _id, string _description, int _x, int _y, string _texturePath)
        {
            this.m = m;
            Name = _name;
            Id = _id;
            Description = _description;
            X = _x;
            Y = _y;
            texturePath = _texturePath;
        }
        public Player(Map _m,XElement PlayerXElement)
        {
            m = _m;
            Name = PlayerXElement.Element("Name").Value;
            id = int.Parse(PlayerXElement.Element("Id").Value);
            description = PlayerXElement.Element("Description").Value;
            x = int.Parse(PlayerXElement.Element("X").Value);
            y = int.Parse(PlayerXElement.Element("Y").Value);
            texturePath = PlayerXElement.Element("CalmTexture").Value;
            attackTexturePath = PlayerXElement.Element("RangedAttack").Value;
            chrouchTexturePath = PlayerXElement.Element("ChrouchTexture").Value;
            meleeTexturePath = PlayerXElement.Element("MeleeAttack").Value;
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
