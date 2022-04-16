using GrandTrainRobbery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GrandTrainRobbery.Data
{
    public class GameDB
    {
        private Map wagon;
        private Player player;
        private List<IEntity> entitys;
        public Player GetPlayer { get => player; }
        public GameDB(int lvl) 
        {
            XElement WagonDefinition = XDocument.Load("WagonDefinitions.xml").Root.Elements("wagon").First(t=>t.Attribute("level").Value==lvl.ToString());

            player = new Player(WagonDefinition.Element("Player"));
        }
    }
}
