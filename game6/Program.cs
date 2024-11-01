namespace game6;

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int score = 0;
        int attempts = 5;
        Random random = new Random();

        Console.WriteLine("Добро пожаловать в игру 'Стрельба по мишеням'!");
        Console.WriteLine("У вас есть 5 попыток, чтобы попасть по мишеням.");
        Console.WriteLine("Нажмите 'Q' для выхода.");

        for (int i = 0; i < attempts; i++)
        {
            Console.Clear();
            int targetPosition = random.Next(1, 11); // Позиция мишени от 1 до 10
            Console.WriteLine("Попробуйте попасть по мишени, она на позиции: " + targetPosition);
            Console.Write("Введите вашу стрельбу (позиция от 1 до 10): ");

            string input = Console.ReadLine();
            if (input.ToUpper() == "Q")
            {
                break;
            }

            if (int.TryParse(input, out int shot))
            {
                if (shot < 1 || shot > 10)
                {
                    Console.WriteLine("Пожалуйста, введите число от 1 до 10.");
                    i--; // Уменьшаем счетчик попыток
                    continue;
                }

                if (shot == targetPosition)
                {
                    Console.WriteLine("Попадание! Вы получили 1 очко.");
                    score++;
                }
                else
                {
                    Console.WriteLine("Промах! Мишень была на позиции " + targetPosition + ".");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите число от 1 до 10.");
                i--; // Уменьшаем счетчик попыток
            }

            Thread.Sleep(1000); // Задержка перед следующим раундом
        }

        Console.Clear();
        Console.WriteLine("Игра окончена! Ваш счет: " + score);
    }
}

