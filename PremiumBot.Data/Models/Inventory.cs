using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBot.Data.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int HeroId { get; set; }
        public virtual Hero Hero { get; set; }
        public virtual List<Armor> Armors { get; set; }
        public virtual List<Food> Foods { get; set; }
        public virtual List<Juice> Juices { get; set; }
    }
}
