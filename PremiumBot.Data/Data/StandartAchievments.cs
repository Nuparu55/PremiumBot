using PremiumBot.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBot.Data.Data
{
    public static class StandartAchievments
    {
        public static List<Achievment> GetStandartAchievments()
        {
            var list = new List<Achievment>();

            list.Add(new Achievment
            {
                Name = "Мега Бульник",
                Condition = "Получить девять реакций на одно свое сообщение",
                Description = "Настоящий анекдот про Наташу Ростову",
                IsUniq = false
            });

            list.Add(new Achievment
            {
                Name = "Дуля Хакана",
                Condition = "Первым получить 20 уровень на существе",
                Description = "Что это такое?",
                IsUniq = true
            });

            list.Add(new Achievment
            {
                Name = "Сиська Гительмана",
                Condition = "Загрузить файл с максимально возможным объемом (2 гигабайта)",
                Description = "Балдеж. Запомните твари - я ебал, меня сосали",
                IsUniq = false
            });

            list.Add(new Achievment
            {
                Name = "Вин Дроссель",
                Condition = "Написать сообщение с максимальным количеством символов (4096)",
                Description = "\"Гонщики не гонят, гонщики гоняют, но не загоняются\"",
                IsUniq = false
            });

            list.Add(new Achievment
            {
                Name = "Защитник кодоев",
                Condition = "Первым получить яйцо золотого кодоя",
                Description = "Сунь цзы искусство яйца в твоём рту",
                IsUniq = false
            });

            list.Add(new Achievment
            {
                Name = "Поносец",
                Condition = "Первым написать сообщение \"понос\"",
                Description = "Настоящий анекдот про Наташу Ростову",
                IsUniq = false
            });

            list.Add(new Achievment
            {
                Name = "Мега бульник",
                Condition = "Получить девять реакций на одно свое сообщение",
                Description = "Настоящий анекдот про Наташу Ростову",
                IsUniq = false
            });

            list.Add(new Achievment
            {
                Name = "Мега бульник",
                Condition = "Получить девять реакций на одно свое сообщение",
                Description = "Настоящий анекдот про Наташу Ростову",
                IsUniq = false
            });

            return list;
        }
    }
}
