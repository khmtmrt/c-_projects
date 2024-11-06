using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3_khomytska
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1
            Console.Write("enter your text here: ");
            string text = Console.ReadLine();

            int count_a = 0;
            int count_o = 0;
            int count_i = 0;
            int count_e = 0;

            foreach (char c in text.ToLower())
            {
                switch (c)
                {
                    case 'a':
                        count_a++;
                        break;
                    case 'o':
                        count_o++;
                        break;
                    case 'i':
                        count_i++;
                        break;
                    case 'e':
                        count_e++;
                        break;
                }
            }

            Console.WriteLine($"the amount of letter 'а': {count_a}");
            Console.WriteLine($"the amount of letter 'о': {count_o}");
            Console.WriteLine($"the amount of letter 'i': {count_i}");
            Console.WriteLine($"the amount of letter 'е': {count_e}");
            int count_all = count_a + count_o + count_e + count_i;
            Console.WriteLine($"the amount of all needed letters is: {count_all}");

            Console.WriteLine("\n\n");

            //2
            Console.Write("enter month number here (1-12):  ");
            string inputMonth = Console.ReadLine();

            // перевірка чи ввели правильне число, конвертація в інт
            int month;
            if (int.TryParse(inputMonth, out month))
            {
                // якщо все правильно ввели то виведення кількості днів у місяці
                int days = GetDaysInMonth(month);

                if (days > 0)
                {
                    Console.WriteLine($"there are {days} days in month number {month}. ");
                }
                else
                {
                    Console.WriteLine("month number should be from 1 to 12 only.");
                }
            }
            else
            {
                Console.WriteLine("value you`ve input is not a number.");
            }

            // для визначення днів у лютому
            int GetDaysInFebruary()
            {
                // поточний рік
                int year = DateTime.Now.Year;

                // чи є високосним
                bool isLeapYear = DateTime.IsLeapYear(year);

                // тарнарний для перевірки щоб вивести або 28 або 29 в залежності від поточного року
                return isLeapYear ? 29 : 28;

            }


            // метод для визначення кількості днів у місяці
            int GetDaysInMonth(int getmonth)
            {
                switch (getmonth)
                {
                    case 1: // січень
                    case 3: // березень
                    case 5: // травень
                    case 7: // липень
                    case 8: // серпень
                    case 10: // жовтень
                    case 12: // грудень
                        return 31;
                    case 4: // квітень
                    case 6: // червень
                    case 9: // вересень
                    case 11: // листопад
                        return 30;
                    case 2: // лютий
                            // високосний
                        return GetDaysInFebruary();
                    default:
                        return 0; // неправильне введення
                }
            }

            Console.WriteLine("\n\n");

            //3

            const int totalNumbers = 10;
            int[] your_input = new int[totalNumbers];

            Console.WriteLine("enter 10 int numbers here: ");

            for (int i = 0; i < totalNumbers; i++)
            {
                Console.Write($"element {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out your_input[i]))
                {
                    Console.WriteLine("enter number.");
                    Console.Write($"element {i + 1}: ");
                }
            }

            // Перевірка, чи всі перші 5 чисел додатні
            bool allPositive = true;
            for (int i = 0; i < 5; i++)
            {
                if (your_input[i] <= 0)
                {
                    allPositive = false;
                    break;
                }
            }

            if (allPositive)
            {
                // цикл для обчислення суми перших 5 елем
                int sum = 0;
                for (int i = 0; i < 5; i++)
                {
                    sum += your_input[i];
                }
                Console.WriteLine($"all 5 first numbers are positive, so sum = {sum}");
            }
            else
            {
                // цикл для обчислення добутку ост 5 елем
                int product = 1;
                for (int i = 5; i < totalNumbers; i++)
                {
                    product *= your_input[i];
                }
                Console.WriteLine($"not all 5 first numbers are positive, so result = {product}");
            }

            Console.ReadKey();
        }

    }
}
