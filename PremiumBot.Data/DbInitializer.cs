using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBot.Data
{
    public static class DbInitializer
    {
        static public void Init()
        {
            using (var db = new BotDBContext())
            {
                db.Database.EnsureCreated();

                if (!db.Achievments.Any())
                {
                    db.AddRange(Data.StandartAchievments.GetStandartAchievments());
                }
            }
        }
    }
}
