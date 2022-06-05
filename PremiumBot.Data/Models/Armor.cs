using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBot.Data.Models
{
    public class Armor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public ArmorType Type { get; set; }
    }

    public enum ArmorType
    {
        Weapon,
        Talisman,
        Armor
    }
}
