using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Конструктор за замовчуванням дефолтний
        public Person(string name, DateTime  year_of_birth) { }

        // Конструктор з 2 параметрами
        public Person(string name, int yearOfBirth)
        {
            this.name = name;
            this.year_of_birth = new DateTime(yearOfBirth, 1, 1); // Ініціалізуємо year_of_birth
        }


        // Input() – для введення інформації про людину
        public static Person Input(int i)
        {
            Console.Write($"enter {i + 1} person's name here: ");
            string name = Console.ReadLine();
            Console.Write($"enter  {i + 1} person's year of birth here: ");
            int year_of_birth = int.Parse(Console.ReadLine());
            Person person = new Person(name, year_of_birth);
            return person;
        }

        // Age() – для обчислення віку людини
        public int Age()
        {
            int age = DateTime.Now.Year - year_of_birth.Year;
            if (DateTime.Now < year_of_birth.AddYears(age)) age--;
            return age;
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

        // Оператор == по імені
        public static bool operator ==(Person p1, Person p2)
        {
            return p1.name == p2.name;
        }

        public static bool operator != (Person p1, Person p2)
        {
            return !(p1 == p2);
        }
        
    }
}
