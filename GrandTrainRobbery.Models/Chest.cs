using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrandTrainRobbery.Models
{
    public class Chest : IEntity
    {
        Map m;
        string name;
        int id;
        int x;
        int y;
        string texturePath;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public XElement source { get; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Map M { get => m; }
        public string TexturePath { get => texturePath; }

        public Chest(Map _m, XElement ChestXElement)
        {
            source = ChestXElement;
            m = _m;
            name = ChestXElement.Element("Name").Value;
            id = int.Parse(ChestXElement.Element("Id").Value);
            x = int.Parse(ChestXElement.Element("X").Value);
            y = int.Parse(ChestXElement.Element("Y").Value);
            texturePath = ChestXElement.Element("CalmTexture").Value;
        }



        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ActualHp => throw new NotImplementedException();
        public bool standing_on_the_ground => throw new NotImplementedException();
        public bool MoveLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool MoveRight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Jump { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Chrouch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool RangedAttacking { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool MeleeAttacking { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
