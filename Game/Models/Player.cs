﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models
{
    class Player : IEntity
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
        public int X { get => x; set => x=value; }
        public int Y { get => y; set => y = value; }
        public string TexturePath { get => texturePath; set => texturePath=value; }

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
