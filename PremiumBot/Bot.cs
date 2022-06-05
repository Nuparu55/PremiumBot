using PremiumBot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using PremiumBot.Utils;

namespace PremiumBot
{
    public class Bot
    {
        private TelegramBotClient _client;
        private User _me;
        private Commands _cmds;
        private AchievmentEvents _achEvnt;

        public Bot()
        {
            _client = new TelegramBotClient(Configuration.BOT_TOKEN);
        }

        public async Task Start()
        {
            //DbInitializer.Init();

            using (var cts = new CancellationTokenSource())
            {

                var opt = new ReceiverOptions
                {
                    AllowedUpdates = { }
                };

                _client.StartReceiving(
                    updateHandler: HandleUpdateAsync,
                    errorHandler: HandlePollingErrorAsync,
                    receiverOptions: opt,
                    cancellationToken: cts.Token
                    );

                _me = await _client.GetMeAsync();
                Console.WriteLine($"ID = {_me.Id}, Name = {_me.Username}, {_me.FirstName}, {_me.LastName}, IsBot = {_me.IsBot}");
                Console.ReadLine();

                cts.Cancel();
            }
        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Type != UpdateType.Message)
                return;
            if (update.Message == null)
                return;

            _cmds = new Commands(botClient, cancellationToken);
            _achEvnt = new AchievmentEvents(botClient, cancellationToken);

            switch (update.Message.Type)
            {
                case MessageType.Text:
                    await TextEventAsync(update);
                    break;
            }
        }

        async Task TextEventAsync(Update update)
        {
            var msg = update.Message.Text.Replace($"@{_me.Username}", "").ToLower().Trim().Split(' ')[0];
            switch (msg)
            {
                //User zone
                case "/register":
                    await _cmds.Register(update);
                    break;
                case "/isadmin":
                    await _cmds.IsAdmin(update);
                    break;
                case "/titles":
                    await _cmds.GetTitles(update);
                    break;

                //Admin zone
                case "/createtitle":
                    await _cmds.CreateTitle(update);
                    break;

                case "/deletetitle":
                    await _cmds.DeleteTitle(update);
                    break;
            }
        }

        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
