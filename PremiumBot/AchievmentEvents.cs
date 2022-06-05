using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using PremiumBot.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace PremiumBot
{
    public class AchievmentEvents
    {
        private ITelegramBotClient _botClient;
        private CancellationToken _cancellationToken;

        public AchievmentEvents(ITelegramBotClient botClient, CancellationToken cancellationToken)
        {
            _botClient = botClient;
            _cancellationToken = cancellationToken;
        }

        async public Task ProcessTextEvent()
        {

        }
    }
}
