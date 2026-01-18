using System;
using System.Text;
using System.Text.RegularExpressions;

namespace LabWork8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування кодування для коректного відображення кирилиці
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Лабораторна робота №8: Регулярні вирази ===");
            Console.WriteLine("Варіант 5: Пошук IP-адрес у тексті\n");

            // Заданий текст, у якому є різні дані та IP-адреси
            string text = "Налаштування сервера: основний шлюз 192.168.0.1, " +
                          "DNS-сервер: 8.8.8.8. Також перевірте локальну адресу 127.0.0.1 " +
                          "та зовнішній вузол 172.16.254.1. Помилкові адреси типу 999.999.999.999 " +
                          "або просто цифри 123.456 не повинні враховуватись.";

            Console.WriteLine("Вхідний текст:");
            Console.WriteLine(text + "\n");

            // Регулярний вираз для пошуку коректної IP-адреси (0-255.0-255.0-255.0-255)
            string pattern = @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

            // Створення об'єкта Regex
            Regex regex = new Regex(pattern);

            // Знаходимо всі збіги
            MatchCollection matches = regex.Matches(text);

            if (matches.Count > 0)
            {
                Console.WriteLine($"Знайдено IP-адрес: {matches.Count}");
                foreach (Match match in matches)
                {
                    Console.WriteLine($"- Знайдено адресу: {match.Value}");
                }
            }
            else
            {
                Console.WriteLine("IP-адреси не знайдено.");
            }

            Console.WriteLine("\nПрограма завершена. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}