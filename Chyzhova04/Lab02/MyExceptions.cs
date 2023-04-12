using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class FutureBirthDateException : Exception
    {
        public FutureBirthDateException()
            : base("Birth date cannot be in the future.") { }
    }

    public class DistantPastBirthDateException : Exception
    {
        public DistantPastBirthDateException()
            : base("Birth date is too far in the past.") { }
    }

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
            : base("Invalid email address.") { }
    }
    public class InvalidFirstNameException : Exception
    {
        public InvalidFirstNameException()
            : base("Invalid first name.") { }
    }

    public class InvalidLastNameException : Exception
    {
        public InvalidLastNameException()
            : base("Invalid last name.") { }
    }
}
