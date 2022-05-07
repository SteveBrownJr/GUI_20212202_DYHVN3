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
        private List<Bullet> bullets;
        public Player GetPlayer { get => player; }
        public Player GetCopyPlayer { get => Player.GetCopy(player); }
        public List<MOB> GetMOBs { get => entitys.Where(t => t is MOB).Select(t=>t as MOB).ToList(); }
        public List<Bullet> GetBullets => bullets;
        public Map GetWagon { get => wagon; }
        public void Killed(IEntity i)
        {
            if (i is MOB)
                entitys.Remove(i);
        }
        public Chest GetChest { get => entitys.Where(c => c is Chest).First() as Chest; }
        public IEnumerable<IEntity> GetEntitys { get => entitys; }
        public List<IEntity> GetEntitysList { get => entitys; }
        public IEnumerable<IEntity> GetCopyEntitys { get => entitys.Select(e=>e).ToList(); }
        public GameDB(int lvl) 
        {
            bullets=new List<Bullet>();
            XElement WagonDefinition = XDocument.Load("WagonDefinitions.xml").Root.Elements("wagon").First(t=>t.Attribute("level").Value==lvl.ToString());
            wagon = new Map(WagonDefinition.Element("Map"));
            player = new Player(wagon,WagonDefinition.Element("Player"),bullets);
            entitys = new List<IEntity>();
            
            foreach (var Xentity in WagonDefinition.Element("Entitys").Elements("Entity"))
            {
                switch (Xentity.Attribute("type").Value)
                {
                    case "MOB":
                        entitys.Add(new MOB(wagon, Xentity));
                        break;
                    case "Chest":
                        entitys.Add(new Chest(wagon, Xentity));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
