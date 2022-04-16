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
        public Player GetCopyPlayer { get => Player.GetCopy(player); }
        public Map GetWagon { get => wagon; }
        public IEnumerable<IEntity> GetEntitys { get => entitys; }
        public IEnumerable<IEntity> GetCopyEntitys { get => entitys.Select(e=>e).ToList(); }
        public GameDB(int lvl) 
        {
            XElement WagonDefinition = XDocument.Load("WagonDefinitions.xml").Root.Elements("wagon").First(t=>t.Attribute("level").Value==lvl.ToString());
            wagon = new Map(WagonDefinition.Element("Map"));
            player = new Player(wagon,WagonDefinition.Element("Player"));
            player.ActualHp = 30;
            //Entitások nem kerülnek példányosításra
        }
    }
}
