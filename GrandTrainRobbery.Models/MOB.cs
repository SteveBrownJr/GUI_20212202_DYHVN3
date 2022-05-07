using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrandTrainRobbery.Models
{
    public class MOB :IEntity
    {
        Random rnd = new Random();
        string name;
        int id;
        int x;
        int y;
        string texturePath;
        string description;
        private int actualHp;
        private bool moveLeft;
        private bool moveRight;
        private bool jump;
        private bool chrouch;
        XElement source;
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
        public bool standing_on_the_ground { get => M.Floor == this.Y; }

        public bool MoveLeft { get => moveLeft; set => moveLeft = value; }
        public bool MoveRight { get => moveRight; set => moveRight=value; }
        public bool Jump { get => jump; set => jump=value; }
        public bool Chrouch { get => chrouch; set => chrouch=value; }
        public int ActualHp { get => actualHp; set => actualHp = value; }
        public void Sebzodik()
        {
            ActualHp -= 5;
        }
        Map M { get => m; }
        Player P;
        List<Bullet> Bullets;

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
                    if (RangedAttackingStatus > 18)
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

        public MOB(Map _m, XElement MOBXElement,Player p, List<Bullet> bullets)
        {
            P = p;
            Bullets = bullets;
            actualHp = 30;
            source = MOBXElement;
            m = _m;
            Name = MOBXElement.Element("Name").Value;
            id = int.Parse(MOBXElement.Element("Id").Value);
            description = MOBXElement.Element("Description").Value;
            x = int.Parse(MOBXElement.Element("X").Value);
            y = int.Parse(MOBXElement.Element("Y").Value);
            texturePath = MOBXElement.Element("CalmTexture").Value;
            attackTexturePath = MOBXElement.Element("RangedAttack").Value;
            chrouchTexturePath = MOBXElement.Element("ChrouchTexture").Value;
            meleeTexturePath = MOBXElement.Element("MeleeAttack").Value;
            jumpTexturePath = MOBXElement.Element("JumpTexture").Value;
            runTexturePath = MOBXElement.Element("RunTexture").Value;


            MoveLeft = false;
            MoveRight = false;
            Jump = false;
            Chrouch = false;
            new Thread(thread=>DoWork()).Start();
        }
        void DoWork()
        {
            while (ActualHp>0)
            {
                Thread.Sleep(1000);
                int percentage = rnd.Next(100);
                if (P.X>X)
                {
                    if (MoveLeft)
                        MoveLeft = false;

                    MoveRight = true;

                    if (percentage<20)
                        RangedAttack();
                }
                if (P.X < X)
                {
                    if (MoveRight)
                        moveRight = false;

                    MoveLeft = true;

                    if (percentage < 20)
                        RangedAttack();
                }
            }
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
                    Bullets.Add(new Bullet("Graphics/Entitys/Bullet/bulletl.png", X - 78, Y + 38, true, false,this));
                }
                if (MoveRight)
                {
                    Bullets.Add(new Bullet("Graphics/Entitys/Bullet/bulletl.png", X + 78, Y + 38, false, true,this));
                }
                RangedAttacking = true;
            }
        }
    }
}
