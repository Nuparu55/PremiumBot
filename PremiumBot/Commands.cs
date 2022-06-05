using PremiumBot.Data;
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
    public class Commands
    {
        private ITelegramBotClient _botClient;
        private CancellationToken _cancellationToken;

        public Commands(ITelegramBotClient botClient, CancellationToken cancellationToken)
        {
            _botClient = botClient;
            _cancellationToken = cancellationToken;
        }

        public async Task<Message> SendMessageToChatAsync(long chatId, string message)
        {
            Message sentMessage = await _botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    cancellationToken: _cancellationToken);
            return sentMessage;
        }

        public async Task Register(Update update)
        {
            using (var db = new BotDBContext())
            {
                var id = update.Message.From?.Id;
                var user = await db.Users.SingleOrDefaultAsync(u => u.TGID == id);
                if (user != null)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Пользователь с ID - {id} уже был зарегистрирован");
                    return;
                }

                var splitted = update.Message.Text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (splitted.Length < 2)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Неверно указан запрос на регистрацию");
                    return;
                }
                var name = String.Join(' ', splitted.Skip(1));
                await db.AddAsync(new Data.Models.User
                {
                    TGID = id.Value,
                    Money = 0,
                    IsAdmin = false,
                    Name = name
                });

                await db.SaveChangesAsync();

                await SendMessageToChatAsync(update.Message.Chat.Id, $"Зарегистрирован пользователь с ID - {id}");
            }
        }

        public async Task IsAdmin(Update update)
        {
            using (var db = new BotDBContext())
            {
                var id = update.Message.From?.Id;
                var user = await db.Users.SingleOrDefaultAsync(u => u.TGID == id);
                if (user == null)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Пользователь {update.Message.From.Username} не зарегистрирован");
                    return;
                }
                var isAdmin = user.IsAdmin;

                await SendMessageToChatAsync(update.Message.Chat.Id, $"Пользователь {update.Message.From.Username} {(isAdmin ? "администратор" : "не администратор")}");
            }
        }

        public async Task CreateTitle(Update update)
        {
            using (var db = new BotDBContext())
            {
                var id = update.Message.From?.Id;
                var user = await db.Users.SingleOrDefaultAsync(u => u.TGID == id);

                if (user == null)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Пользователь {update.Message.From.Username} не зарегистрирован");
                    return;
                }
                if (!user.IsAdmin)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Пользователь {update.Message.From.Username} не администратор");
                    return;
                }
                var splittedMsg = update.Message.Text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (splittedMsg.Length < 2)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Неверно указан запрос на создание титула");
                    return;
                }
                var titleText = String.Join(' ', splittedMsg.Skip(1));
                var isExist = await db.Titles.AnyAsync(t => t.Name.ToLower() == titleText.ToLower());
                if (isExist)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Титул {titleText} уже существует");
                    return;
                }
                await db.AddAsync(new Title { Name = titleText, Rare = Rare.Common });

                await SendMessageToChatAsync(update.Message.Chat.Id, $"Титул {titleText} добавлен");

                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteTitle(Update update)
        {
            using (var db = new BotDBContext())
            {
                var id = update.Message.From?.Id;
                var user = await db.Users.SingleOrDefaultAsync(u => u.TGID == id);

                if (user == null)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Пользователь {update.Message.From.Username} не зарегистрирован");
                    return;
                }
                if (!user.IsAdmin)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Пользователь {update.Message.From.Username} не администратор");
                    return;
                }

                var splittedMsg = update.Message.Text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (splittedMsg.Length != 2)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Неверно указан запрос на удаление титула");
                    return;
                }

                int titleId;
                if (!Int32.TryParse(splittedMsg[1], out titleId))
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Неверно указан запрос на удаление титула");
                    return;
                }
                var title = await db.Titles.SingleOrDefaultAsync(t => t.Id == titleId);
                if (title == null)
                {
                    await SendMessageToChatAsync(update.Message.Chat.Id, $"Титула с ID {titleId} не существует");
                    return;
                }
                db.Titles.Remove(title);
                await db.SaveChangesAsync();

                await SendMessageToChatAsync(update.Message.Chat.Id, $"Титул {title.Name} удален");
            }
        }

        public async Task GetTitles(Update update)
        {
            using (var db = new BotDBContext())
            {
                var titles = String.Join('\n', db.Titles.Select(t => $"{t.Id} - {t.Name}"));

                await SendMessageToChatAsync(update.Message.Chat.Id, $"Список титулов\n{titles}");
            }
        }
    }
}
