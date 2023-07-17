using Telegram.Bot;
using System.Text.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

const string TOKEN = "TOKEN";
var opt = new JsonSerializerOptions { WriteIndented = true };
using CancellationTokenSource cts = new ();

var botClient = new TelegramBotClient(TOKEN);

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new ()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandleErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();
Console.WriteLine(JsonSerializer.Serialize(me, opt));
Console.ReadLine(); //wait to exit

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    Console.WriteLine(JsonSerializer.Serialize(update,opt));
}

async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    Console.WriteLine(JsonSerializer.Serialize(exception, opt));
}