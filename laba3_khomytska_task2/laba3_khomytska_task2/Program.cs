using System;

namespace laba3_khomytska_task2
{
    class Person
    {
        // Приватні поля: ім’я та рік народження
        private string name;
        private DateTime year_of_birth;

        // Властивості для доступу до полів лише get
        public string Name => name;
        public DateTime Year_of_birth => year_of_birth;

        // Конструктор за замовчуванням
        public Person() { }

        // Конструктор з 2 параметрами
        public Person(string name, DateTime year_of_birth)
        {
            this.name = name;
            this.year_of_birth = year_of_birth;
        }

        // Age() – для обчислення віку людини
        public int Age()
        {
            int age = DateTime.Now.Year - year_of_birth.Year;
            if (DateTime.Now < year_of_birth.AddYears(age)) age--;
            return age;
        }

        // Input() – для введення інформації про людину
        public void Input()
        {
            Console.Write("enter person's name here: ");
            name = Console.ReadLine();

            Console.Write("enter person's year of birth here: ");
            int year = int.Parse(Console.ReadLine());
            year_of_birth = new DateTime(year, 1, 1);
        }

        // ChangeName() – щоб змінити ім’я людини
        public void ChangeName()
        {
            name = "Very Young";
        }

        // ToString()
        public override string ToString()
        {
            return $"Name: {name}, Year of Birth: {year_of_birth.Year}, Age: {Age()}";
        }

        // Output() – для виведення інформації про людину
        public void Output()
        {
            Console.WriteLine(ToString());
        }

        // Оператор ==
        public static bool operator ==(Person p1, Person p2)
        {
            return p1.name.Equals(p2.name, StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this == person;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int people_quantity = 6; // Зміна на 6 для тестування
            Person[] people = new Person[people_quantity];

            for (int i = 0; i < people_quantity; i++)
            {
                Console.WriteLine($"information about person {i + 1}: ");
                people[i] = new Person();
                people[i].Input();
            }

            // Виведення інформації та обчислення віку
            Console.WriteLine("\nage and info about people:");
            foreach (var person in people)
            {
                person.Output();
            }

            // Зміна імені осіб з віком менше 16 років
            foreach (var person in people)
            {
                if (person.Age() < 16)
                {
                    person.ChangeName();
                }
            }

            // Виведення інформації про всіх людей після зміни імені
            Console.WriteLine("\ninfo after name change:");
            foreach (var person in people)
            {
                person.Output();
            }

            // Знаходження осіб з однаковими іменами
            Console.WriteLine("\npeople with same names:");
            for (int i = 0; i < people.Length; i++)
            {
                for (int j = i + 1; j < people.Length; j++)
                {
                    if (people[i] == people[j])
                    {
                        Console.WriteLine($"{people[i].Name} and {people[j].Name} have same names.");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
