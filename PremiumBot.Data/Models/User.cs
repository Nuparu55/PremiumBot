using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBot.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public long TGID { get; set; }
        public string Name { get; set; }
        public int Fragments { get; set; }
        public int AuthorCoins { get; set; }
        public bool IsAdmin { get; set; }
        public virtual List<Achievment> Achievments { get; set; }
        public virtual Hero Hero { get; set; }

        //Activity counters
        public int MessagesCount { get; set; }
        public int ImagesCount { get; set; }
        public int ReactionsCount { get; set; }
        public int ReplyCount { get; set; }
        public int RedirectCount { get; set; }
        public int StickersCount { get; set; }
        public int FilesCount { get; set; }
        public int GeopositionsCount { get; set; }
        public int PoolsCount { get; set; }
        public int ContactsCount { get; set; }
    }
}
