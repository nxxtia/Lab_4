using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

namespace Lab02
{
    public class PersonRepository
    {
        private List<Person> _persons;

        private void GenerateSampleData()
        {
            Random random = new Random();
            string[] firstNames = { "John", "Alice", "Bob", "Cathy", "David", "Emma" };
            string[] lastNames = { "Smith", "Johnson", "Brown", "Williams", "Miller", "Davis" };
            string[] emails = { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "example.com" };

            for (int i = 0; i < 50; i++)
            {
                string firstName = firstNames[random.Next(firstNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];
                string email = $"{firstName.ToLower()}_{lastName.ToLower()}@{emails[random.Next(emails.Length)]}";
                DateTime dateOfBirth = new DateTime(random.Next(1950, 2005), random.Next(1, 13), random.Next(1, 29));

                Add(new Person
                {
                    Id = i + 1,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    DateOfBirth = dateOfBirth
                });
            }
        }

        public PersonRepository()
        {
            _persons = new List<Person>();
        }

        public List<Person> GetAll()
        {
            return _persons;
        }

        public Person Get(int id)
        {
            return _persons.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Person person)
        {
            _persons.Add(person);
        }

        public void Update(Person person)
        {
            int index = _persons.FindIndex(p => p.Id == person.Id);
            if (index >= 0)
            {
                _persons[index] = person;
            }
        }

        public void Delete(int id)
        {
            _persons.RemoveAll(p => p.Id == id);
        }

        public void SaveData()
        {
            using (StreamWriter file = File.CreateText("persons.json"))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, _persons);
            }
        }

        public void LoadData()
        {
            if (File.Exists("persons.json"))
            {
                // Файл існує, завантажте дані з файлу
                using (StreamReader file = File.OpenText("persons.json"))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    _persons = (List<Person>)serializer.Deserialize(file, typeof(List<Person>));
                }
            }
            else
            {
               
                GenerateSampleData();

                // Збережіть створених користувачів у файл
                SaveData();
            }
        }
    }
}
