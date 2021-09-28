using System;
using System.Collections.Generic;
using System.Text;


namespace shrap_lab_1
{
    class Person
    {

        string name;
        string surname;
        DateTime birthday;
        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;

        }
        public Person() : this("Иван", "Иванов", new DateTime (2000, 12, 27))
        {
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }

        public int Year
        {
            get
            {
                return birthday.Year;
            }
            set
            {
                birthday = new DateTime(value, birthday.Month, birthday.Day);
            }
        }

        public override string ToString()
        {
           return Name+" "+ Surname+" "+ birthday.ToShortDateString();

        }
        public virtual string ToShortString()
        {
            return Name + " " + Surname + " ";

        }
    }

}
