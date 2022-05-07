using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrandTrainRobbery.Models
{
    public class Player : IEntity
    {
        int actualhp;
        string name;
        int id;
        int x;
        int y;
        string texturePath;
        string description;
        Map m;
        string meleeTexturePath;
        string attackTexturePath;
        string chrouchTexturePath;
        string jumpTexturePath;
        string runTexturePath;
        public string TexturePath { get => texturePath; }
        public string RunTexturePath { get => runTexturePath; }
        public string JumpTexturePath { get => jumpTexturePath; }
        public string MeleeTexturePath { get => meleeTexturePath; }
        public string AttackTexturePath { get => attackTexturePath; }
        public string ChrouchTexturePath { get => chrouchTexturePath; }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public bool standing_on_the_ground { get => m.Floor == this.Y; }
        public XElement source { get; }
        public Map M { get => m; }
        public bool MoveLeft {get;set;}
        public bool MoveRight { get; set; }
        public bool Jump { get; set; }
        public bool Chrouch { get; set; }
        public int ActualHp { get { return this.actualhp; } set { actualhp = value; } }
        int RangedAttackingStatus = 0;
        int MeleeAttackingStatus = 0;
        bool rangedattacking = false;
        bool meleeattacking = false;
        public bool RangedAttacking 
        {
            get 
            {
                if (rangedattacking)
                {
                    if (RangedAttackingStatus > 15)
                    {
                        rangedattacking = false;
                        RangedAttackingStatus = 0;
                    }
                    else
                    {
                        RangedAttackingStatus++;
                    }
                }
                return rangedattacking;
            }
            set
            {
                rangedattacking = value;
                RangedAttackingStatus = 0;
            }
        }
        public bool MeleeAttacking
        {
            get
            {
                if (meleeattacking)
                {
                    if (MeleeAttackingStatus > 3)
                    {
                        meleeattacking = false;
                        MeleeAttackingStatus = 0;
                    }
                    else
                    {
                        MeleeAttackingStatus++;
                    }
                }
                return meleeattacking;
            }
            set
            {
                if (!meleeattacking)
                {
                    meleeattacking = value;
                }
                MeleeAttackingStatus = 0;
            }
        }
        private List<Bullet> Bullets;

        public Player(Map _m, XElement PlayerXElement,List<Bullet> bullets)
        {
            Bullets = bullets;
            actualhp = 30;
            source = PlayerXElement;
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
            jumpTexturePath = PlayerXElement.Element("JumpTexture").Value;
            runTexturePath = PlayerXElement.Element("RunTexture").Value;

            MoveLeft = false;
            MoveRight = false;
            Jump = false;
            Chrouch = false;
        }
        public Player(Map _m, XElement PlayerXElement)
        {
            Bullets = new List<Bullet>();
            actualhp = 30;
            source = PlayerXElement;
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
            jumpTexturePath = PlayerXElement.Element("JumpTexture").Value;
            runTexturePath = PlayerXElement.Element("RunTexture").Value;

            MoveLeft = false;
            MoveRight = false;
            Jump = false;
            Chrouch = false;
        }

        public static Player GetCopy(Player old)
        {
            Player p = new Player(old.M, old.source);
            p.X = old.X;
            p.Y = old.Y;
            p.MoveLeft = false;
            p.MoveRight = false;
            p.Jump = false;
            p.Chrouch = false;
            return p;
        }
        public void MeleeAttack()
        {
            MeleeAttacking = true;
        }

        public void RangedAttack()
        {
            if (!rangedattacking && standing_on_the_ground)
            {
                if (MoveLeft)
                {
                    Bullets.Add(new Bullet("Graphics/Entitys/Bullet/bulletl.png", X - 78, Y+38, true, false));
                }
                else
                {
                    Bullets.Add(new Bullet("Graphics/Entitys/Bullet/bulletr.png",X+78,Y+38,false,true));
                }
               
                RangedAttacking = true;        
            }
        }
    }
}
