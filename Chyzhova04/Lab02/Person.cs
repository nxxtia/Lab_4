using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lab02;

namespace Lab02
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Id { get; set; }

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {

            //FirstName = firstName;
            //LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;

            if (IsValidFirstName(firstName))
            {
                FirstName = firstName;
            }

            if (IsValidLastName(lastName))
            {
                LastName = lastName;
            }

            if (dateOfBirth > DateTime.Now)
            {
                throw new FutureBirthDateException();
            }

            int age = CalculateAge(DateOfBirth);
            if (age < 0 || age > 135)
            {
                throw new DistantPastBirthDateException();
            }

            if (!IsValidEmail(email))
            {
                throw new InvalidEmailException();
            }
        }

        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public Person()
        {
        }

        public bool IsAdult
        {
            get
            {
                return CalculateAge(DateOfBirth) >= 18;
            }
        }

        public string SunSign
        {
            get
            {
                return ZodiacHelper.GetWesternZodiacSign(DateOfBirth);
            }
        }

        public string ChineseSign
        {
            get
            {
                return ZodiacHelper.GetChineseZodiacSign(DateOfBirth);
            }
        }

        public bool IsBirthday
        {
            get
            {
                return DateOfBirth.Day == DateTime.Now.Day && DateOfBirth.Month == DateTime.Now.Month;
            }
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
                age -= 1;

            return age;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                {
                    throw new InvalidEmailException();
                }
            }
            catch
            {
                throw new InvalidEmailException();
            }

            return true;
        }
        public static bool IsValidFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName) || !char.IsUpper(firstName[0]))
            {
                throw new InvalidFirstNameException();
            }

            return true;
        }

        public static bool IsValidLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName) || !char.IsUpper(lastName[0]))
            {
                throw new InvalidLastNameException();
            }

            return true;
        }
    }
}
