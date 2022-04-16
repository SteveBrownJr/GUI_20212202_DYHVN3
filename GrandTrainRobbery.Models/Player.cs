﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrandTrainRobbery.Models
{
    public class Player : IEntity
    {
        int actualhp;
        int maxhp;
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

        public string TexturePath { get => texturePath; }
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
        public Map M { get; }
        public bool MoveLeft {get;set;}
        public bool MoveRight { get; set; }
        public bool Jump { get; set; }
        public bool Chrouch { get; set; }
        public int ActualHp { get { return this.actualhp; } }
        public int MaxHp { get { return this.maxhp; } }

        public Player(Map _m, XElement PlayerXElement)
        {
            actualhp = 30;
            maxhp = 30;
            source = PlayerXElement;
            M = _m;
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
            throw new NotImplementedException();
        }

        public void RangedAttack()
        {
            throw new NotImplementedException();
        }
    }
}
