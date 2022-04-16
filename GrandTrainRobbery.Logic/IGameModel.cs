﻿using GrandTrainRobbery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Logic
{
    public interface IGameModel
    {
        public string GetLevelPath();
        public Player GetPlayer();
    }
}