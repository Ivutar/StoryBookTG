using Telegram.Bot;
using System.Text.Json;

var botClient = new TelegramBotClient("TOKEN");

var me = await botClient.GetMeAsync();
Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

var meJson = JsonSerializer.Serialize(me, new JsonSerializerOptions { WriteIndented = true });
Console.WriteLine(meJson);