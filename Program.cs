using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TgBotForRozklad
{
    class Program
    {

        private static string token { get; set; } = "token";
        private static TelegramBotClient client;

        static void Main(string[] args)
        {

            Console.WriteLine(); 
            client = new TelegramBotClient(token);

            client.StartReceiving();
            client.OnMessage += OnMessageHandler;

            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом: {msg.Text}");
                switch (msg.Text)
                {
                    case "Розклад на сьогодні":
                        switch (DateTime.Now.DayOfWeek)
                        {
                            case DayOfWeek.Monday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Monday: ", replyMarkup: GetButtons());
                                await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/V3LkDbR/2021-09-04-235126.png", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Tuesday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Tuesday: ", replyMarkup: GetButtons());
                                await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/qDB5Tt4/2021-09-04-235227.png", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Wednesday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Wednesday: ", replyMarkup: GetButtons());
                                await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/Db2vsQN/2021-09-04-235319.png", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Thursday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Thursday: ", replyMarkup: GetButtons());
                                await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/7k1pmdQ/2021-09-04-235353.png", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Friday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Friday: ", replyMarkup: GetButtons());
                                await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/1TbQP7x/2021-09-04-235438.png", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Saturday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Якій розклад чел? Сьогодні відпочивай...", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Sunday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Прийдеш завтра або нажми кнопочку \"Розклад на завтра\"", replyMarkup: GetButtons());

                                break;

                        }
                        break;


                    case "Розклад на тиждень":
                        await client.SendTextMessageAsync(msg.Chat.Id, "Week: ", replyMarkup: GetButtons());
                        await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/vH8gvYK/image.png", replyMarkup: GetButtons());
                        break;

                    case "Розклад дзвінків":
                        await client.SendTextMessageAsync(msg.Chat.Id, "Розклад дзвінків: ", replyMarkup: GetButtons());
                        await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/L8qc70F/2021-09-23-150118.png", replyMarkup: GetButtons());
                        break;

                    case "Розміщення аудиторій":
                        await client.SendTextMessageAsync(msg.Chat.Id, "Розміщення аудиторій: ", replyMarkup: GetButtons());
                        await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/x7ycxNT/2021-09-23-150202.png", replyMarkup: GetButtons());
                        break;

                    case "Розклад на завтра":

                        switch (DateTime.Now.DayOfWeek)
                        {
                            case DayOfWeek.Monday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Tuesday: ", replyMarkup: GetButtons());
                                await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/qDB5Tt4/2021-09-04-235227.png", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Tuesday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Wednesday: ", replyMarkup: GetButtons());
                                await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/Db2vsQN/2021-09-04-235319.png", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Wednesday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Thursday: ", replyMarkup: GetButtons());
                                await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/7k1pmdQ/2021-09-04-235353.png", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Thursday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Friday: ", replyMarkup: GetButtons());
                                await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/1TbQP7x/2021-09-04-235438.png", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Friday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Розлабся, дядь, завтра вихідний =)", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Saturday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Завтра вихідний, чуваче", replyMarkup: GetButtons());
                                break;
                            case DayOfWeek.Sunday:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Monday: ", replyMarkup: GetButtons());
                                await client.SendPhotoAsync(msg.Chat.Id, photo: "https://i.ibb.co/V3LkDbR/2021-09-04-235126.png", replyMarkup: GetButtons());
                                break;
                            default:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Ошибка: ", replyMarkup: GetButtons());
                                break;

                        }
                        break;


                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Виберіть команду: ", replyMarkup: GetButtons());
                        break;



                }
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Розклад на сьогодні"}, new KeyboardButton { Text = "Розклад на завтра"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Розклад на тиждень" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Розклад дзвінків"}, new KeyboardButton { Text = "Розміщення аудиторій"} }
                }

            };
        }
    }

}
