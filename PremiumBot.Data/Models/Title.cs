using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBot.Data.Models
{
    public class Title
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Rare Rare { get; set; }
        public virtual List<User> Users {  get; set; }
    }

    public enum Rare
    {
        Common,
        Rare,
        Epic,
        Legendary
    }
}
