using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBot.Data.Models
{
    public class Achievment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string ConditionCode { get; set; }
        public bool IsUniq { get; set; }
        public string ImgPath { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
