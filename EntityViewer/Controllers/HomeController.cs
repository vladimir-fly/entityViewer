﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Util;
using EntityViewer.Models;
using Newtonsoft.Json;

namespace EntityViewer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Viewer()
        {
            var location = new Location
            {
                Description = "Main location",
                Id = "location1",
                Name = "BaseLocation",
                Players = new List<Player>
                {
                    new Player { Health = 50, Id = "player1", Stamina = 120 },
                    new Player { Health = 100, Id = "player2", Stamina = 150 }
                },
                Size = 100
            };

            var backpack = new Backpack
            {
                Items = new List<IEntity>
                {
                    new StuffItem {Name = "Item1_name", Id = "item1", Stock = new List<string> {"Item1_stock1", "Item1_stock2", "Item1_stock3"}},
                    new StuffItem {Name = "Item2_name", Id = "item2", Stock = new List<string> {"Item2_stock1", "Item2_stock2", "Item2_stock3"}},
                    new StuffItem {Name = "Item3_name", Id = "item3", Stock = new List<string> {"Item3_stock1", "Item3_stock2", "Item3_stock3"}},
                    new StuffItem {Name = "Item4_name", Id = "item4", Stock = new List<string> {"Item4_stock1", "Item4_stock2", "Item4_stock3"}},
                },
                Weight = 100,
                Id = "backpack1"
            };

            //return View(location);
            return View(backpack);
        }

        public ActionResult Index(IEnumerable<Item> model)
        {
            Items = new List<Item>
            {
                new Item {new Component(), new Component(), new Component(),
                    new Item {new Item(), new Item(), new Item(), new Component()}},
                new Item {new Item(), new Item {new Item(), new Item()}, new Item()},
                new Item {new Component(), new Component(), new Component(), new Item()},
                new Item {new Component(), new Component()},
                new Item {new Item(), new Item(), new Item() },
                new Item {new Item(), new Item(), new Item(), new Item()},
                new Item {new Component(), new Component(), new Component()},
                new Item {new Item{new Component(), new Item{new Item{new Component(), new Component()}}}},
                new Item {new Item{new Item{new Item{new Component()}}}},
                new Item {new Item{new Item(), new Item(), new Item()}},
                new Item {new Component(), new Component(), new Component(), new Component()},
                new Item(),
                new Item {new Item(), new Component(), new Component(), new Item()}
            };

            return View(model ?? Items);
        }

        public ActionResult Inspector()
        {
            var tmpItem = new Weapon
            {
                Childs = { new Item(), new Item(), new Item() },
                Components = { new Component(), new Component(), new Component() },
                Data = "New weapon"
            };
            return View(tmpItem);
        }

        public void SaveItem(Item item)
        {
            Items?.RemoveAll(i => i.Id == item.Id);
            Items?.Add(item);
        }

        public void SaveItemsToJson(IEnumerable<Item> items)
        {
            var json = JsonConvert.SerializeObject(items);
            System.IO.File.WriteAllText("items.json", json);
        }

        public List<Item> Items { get; set; }
    }
}