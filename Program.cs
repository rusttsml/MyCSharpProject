using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Меню ===");
            Console.WriteLine("1. FizzBuzz");
            Console.WriteLine("2. Обчислення відсотка");
            Console.WriteLine("3. Формування числа з 4 цифр");
            Console.WriteLine("4. Обмін цифр у шестизначному числі");
            Console.WriteLine("5. Сезон і день тижня за датою");
            Console.WriteLine("6. Конвертер температури");
            Console.WriteLine("7. Парні числа в діапазоні");
            Console.WriteLine("8. Число Армстронга");
            Console.WriteLine("9. Досконале число");
            Console.WriteLine("0. Вийти");
            Console.Write("Виберіть завдання: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": Task1_FizzBuzz(); break;
                case "2": Task2_Percentage(); break;
                case "3": Task3_JoinDigits(); break;
                case "4": Task4_SwapDigits(); break;
                case "5": Task5_SeasonAndDay(); break;
                case "6": Task6_TemperatureConverter(); break;
                case "7": Task7_EvenNumbersInRange(); break;
                case "8": Task8_ArmstrongNumber(); break;
                case "9": Task9_PerfectNumber(); break;
                case "0": return;
                default: Console.WriteLine("Невірний вибір."); break;
            }
        }
    }

    static void Task1_FizzBuzz()
    {
        Console.Write("Введіть число від 1 до 100: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number < 1 || number > 100)
            {
                Console.WriteLine("Помилка: число повинно бути від 1 до 100.");
            }
            else if (number % 3 == 0 && number % 5 == 0)
                Console.WriteLine("Fizz Buzz");
            else if (number % 3 == 0)
                Console.WriteLine("Fizz");
            else if (number % 5 == 0)
                Console.WriteLine("Buzz");
            else
                Console.WriteLine(number);
        }
        else Console.WriteLine("Помилка: введено не число.");
    }

    static void Task2_Percentage()
    {
        Console.Write("Введіть значення: ");
        if (double.TryParse(Console.ReadLine(), out double value))
        {
            Console.Write("Введіть відсоток: ");
            if (double.TryParse(Console.ReadLine(), out double percent))
            {
                double result = value * percent / 100;
                Console.WriteLine($"{percent}% від {value} = {result}");
            }
            else Console.WriteLine("Помилка: введено не відсоток.");
        }
        else Console.WriteLine("Помилка: введено не число.");
    }

    static void Task3_JoinDigits()
    {
        Console.WriteLine("Введіть 4 цифри:");
        string result = "";
        for (int i = 1; i <= 4; i++)
        {
            Console.Write($"Цифра {i}: ");
            string digit = Console.ReadLine();
            if (digit.Length != 1 || !char.IsDigit(digit[0]))
            {
                Console.WriteLine("Це не цифра.");
                return;
            }
            result += digit;
        }
        Console.WriteLine("Сформоване число: " + result);
    }

    static void Task4_SwapDigits()
    {
        Console.Write("Введіть шестизначне число: ");
        string input = Console.ReadLine();

        if (input.Length != 6 || !int.TryParse(input, out _))
        {
            Console.WriteLine("Помилка: число повинно бути шестизначним.");
            return;
        }

        Console.Write("Введіть перший розряд (1-6): ");
        int pos1 = int.Parse(Console.ReadLine()) - 1;
        Console.Write("Введіть другий розряд (1-6): ");
        int pos2 = int.Parse(Console.ReadLine()) - 1;

        if (pos1 < 0 || pos1 > 5 || pos2 < 0 || pos2 > 5)
        {
            Console.WriteLine("Розряди мають бути від 1 до 6.");
            return;
        }

        char[] chars = input.ToCharArray();
        (chars[pos1], chars[pos2]) = (chars[pos2], chars[pos1]);
        Console.WriteLine("Результат: " + new string(chars));
    }

    static void Task5_SeasonAndDay()
    {
        Console.Write("Введіть дату (дд.мм.рррр): ");
        string input = Console.ReadLine();

        if (DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
        {
            string season = date.Month switch
            {
                12 or 1 or 2 => "Winter",
                3 or 4 or 5 => "Spring",
                6 or 7 or 8 => "Summer",
                9 or 10 or 11 => "Autumn",
                _ => "Unknown"
            };

            string day = date.DayOfWeek.ToString();
            Console.WriteLine($"{season} {day}");
        }
        else Console.WriteLine("Помилка: неправильний формат дати.");
    }

    static void Task6_TemperatureConverter()
    {
        Console.Write("Введіть температуру: ");
        if (double.TryParse(Console.ReadLine(), out double temp))
        {
            Console.Write("Оберіть напрямок (1 - F → C, 2 - C → F): ");
            string choice = Console.ReadLine();

            if (choice == "1")
                Console.WriteLine($"Температура в Цельсіях: {(temp - 32) * 5 / 9:F2}");
            else if (choice == "2")
                Console.WriteLine($"Температура у Фаренгейтах: {(temp * 9 / 5) + 32:F2}");
            else
                Console.WriteLine("Невірний вибір.");
        }
        else Console.WriteLine("Помилка: введено не число.");
    }

    static void Task7_EvenNumbersInRange()
    {
        Console.Write("Введіть перше число: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введіть друге число: ");
        int b = int.Parse(Console.ReadLine());

        if (a > b) (a, b) = (b, a); // нормалізація

        Console.WriteLine("Парні числа в діапазоні:");
        for (int i = a; i <= b; i++)
        {
            if (i % 2 == 0)
                Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    static void Task8_ArmstrongNumber()
    {
        Console.Write("Введіть число: ");
        if (int.TryParse(Console.ReadLine(), out int num))
        {
            int sum = 0;
            int digits = num.ToString().Length;
            int temp = num;

            while (temp > 0)
            {
                int d = temp % 10;
                sum += (int)Math.Pow(d, digits);
                temp /= 10;
            }

            Console.WriteLine(sum == num ? "Це число Армстронга." : "Це не число Армстронга.");
        }
        else Console.WriteLine("Помилка: введено не число.");
    }

    static void Task9_PerfectNumber()
    {
        Console.Write("Введіть число: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                    sum += i;
            }

            Console.WriteLine(sum == number ? "Це досконале число." : "Це не досконале число.");
        }
        else Console.WriteLine("Помилка: введено не число.");
    }
}
