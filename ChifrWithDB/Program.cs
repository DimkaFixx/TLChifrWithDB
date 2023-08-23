namespace ChifrWithDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chifr chifr = new Chifr();  
                        
            Console.WriteLine("Вы хотите зашифровать (Y) сообщение или расшифровать (N)?:");
            string isChipher = Console.ReadLine();
            Console.WriteLine("На какое кол-во делений смещение по часовой стрелке? (положительное число):");
            int countbias = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите сообщение:");
            string message = Console.ReadLine();

            if (isChipher == "Y")
            {
                Console.WriteLine($"Ваше сообщение: {chifr.Chifrator(message, countbias)}");
            }
            else
            {
                Console.WriteLine($"Ваше сообщение: {chifr.DeChifrator(message, countbias)}");
            }
        }
    }
}