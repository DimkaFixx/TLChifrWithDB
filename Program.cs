using System;
using System.Linq;

namespace ChifrWithDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chifr chifr = new Chifr();

            Console.WriteLine("Вы хотите зашифровать (Y) сообщение или расшифровать (N)?:");
            string isChipher = Console.ReadLine();
            

            if (isChipher == "Y")
            {
                Console.WriteLine("На какое кол-во делений смещение по часовой стрелке? (положительное число):");
                int countbias = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите сообщение:");
                string message = Console.ReadLine();

                string chifredmess = chifr.Chifrator(message, countbias);
                Console.WriteLine($"Ваше сообщение: {chifredmess} уже в базе данных");

                using (ApplicationContext db = new ApplicationContext())
                {
                    User todb = new User { ChifredMessage = chifredmess, Biases = countbias };

                    // добавляем их в бд
                    db.Users.AddRange(todb);
                    db.SaveChanges();
                }

            }
            else
            {
                //Console.WriteLine($"Ваше сообщение: {chifr.DeChifrator(message, countbias)}");

                Console.WriteLine("Напишите, расшифрока какого сообщения вам нужна? (вводить id): ");
                int chifrid = int.Parse(Console.ReadLine());

                using (ApplicationContext db = new ApplicationContext())
                {
                    // получаем объекты из бд и выводим на консоль
                    var users = db.Users.ToList();
                    Console.WriteLine("Ваше сообщение:");
                    foreach (User u in users)
                    {
                        if (u.Id == chifrid)
                        {
                            Console.WriteLine(chifr.DeChifrator(u.ChifredMessage, u.Biases));
                        }
                        
                    }
                }
            }
        }
    }
}