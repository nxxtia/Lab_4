using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public static class ZodiacHelper
    {
        public static string GetWesternZodiacSign(DateTime dateOfBirth)
        {
            int day = dateOfBirth.Day;
            int month = dateOfBirth.Month;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                    {
                        return "Capricorn";
                    }
                    else
                    {
                        return "Aquarius";
                    }
                case 2:
                    if (day <= 18)
                    {
                        return "Aquarius";
                    }
                    else
                    {
                        return "Pisces";
                    }
                case 3:
                    if (day <= 20)
                    {
                        return "Pisces";
                    }
                    else
                    {
                        return "Aries";
                    }
                case 4:
                    if (day <= 19)
                    {
                        return "Aries";
                    }
                    else
                    {
                        return "Taurus";
                    }
                case 5:
                    if (day <= 20)
                    {
                        return "Taurus";
                    }
                    else
                    {
                        return "Gemini";
                    }
                case 6:
                    if (day <= 20)
                    {
                        return "Gemini";
                    }
                    else
                    {
                        return "Cancer";
                    }
                case 7:
                    if (day <= 22)
                    {
                        return "Cancer";
                    }
                    else
                    {
                        return "Leo";
                    }
                case 8:
                    if (day <= 22)
                    {
                        return "Leo";
                    }
                    else
                    {
                        return "Virgo";
                    }
                case 9:
                    if (day <= 22)
                    {
                        return "Virgo";
                    }
                    else
                    {
                        return "Libra";
                    }
                case 10:
                    if (day <= 22)
                    {
                        return "Libra";
                    }
                    else
                    {
                        return "Scorpio";
                    }
                case 11:
                    if (day <= 21)
                    {
                        return "Scorpio";
                    }
                    else
                    {
                        return "Sagittarius";
                    }
                case 12:
                    if (day <= 21)
                    {
                        return "Sagittarius";
                    }
                    else
                    {
                        return "Capricorn";
                    }
                default:
                    return "";
            }
        }

        public static string GetChineseZodiacSign(DateTime dateOfBirth)
        {
            int year = dateOfBirth.Year;
            switch (year % 12)
            {
                case 0:
                    return "Monkey";
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
                default:
                    return "";
            }
        }
    }
}
