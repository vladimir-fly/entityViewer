using System.Collections.Generic;

namespace EntityViewer.Models
{
    public interface IEntity
    {
        string Id { get; set; }
    }

    [DisplayEntityType(DisplayType.Property)]
    public class Location : IEntity
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public List<Player> Players { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
    }

    [DisplayEntityType(DisplayType.Collection)]
    public class Backpack : IEntity
    {
        public List<IEntity> Items;
        public int Weight;
        public string Id { get; set; }
    }

    public class Level : IEntity
    {
        public int Value;
        public string Name;
        public string Id { get; set; }
    }

    public class StuffItem : IEntity
    {
        public List<string> Stock;
        public string Name;
        public string Id { get; set; }
    }

    public class Player : IEntity
    {
        public int Health;
        public int Stamina;
        public string Name;
        public Backpack Backpack;
        public string Id { get; set; }
    }

    public class Scene : IEntity
    {
        public List<Player> Players;
        public string Id { get; set; }
    }

    public class Weapon : Item
    {
        public string Data { get; set; }
    }

}