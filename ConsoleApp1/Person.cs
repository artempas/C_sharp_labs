using System;
using System.Collections.Generic;
using System.Text;


namespace sharp_lab_1
{
    class Person
    {

        string name;
        string surname;
        DateTime birthday;
        
        //CONSTRUCTORS
        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;

        }
        public Person() : this("Иван", "Иванов", new DateTime (2000, 12, 27))
        {
        }

        //PROPERTIES
        public string Name
        {
            get => name;
            set => name = value;
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

        
        //METHODS
        
        public override bool Equals(object? obj)
        {
            Person p = obj as Person;
            return (name == p.name && surname==p.surname && p.birthday == birthday);
        }


        public override int GetHashCode()
        {
            return surname.GetHashCode()+name.GetHashCode()+birthday.GetHashCode();
        }


        public object DeepCopy() => new Person(name, surname, birthday);
        

        public override string ToString()
        {
           return Name+" "+ Surname+" "+ birthday.ToShortDateString();

        }
        public virtual string ToShortString()
        {
            return Name + " " + Surname + " ";

        }
        
        
        //OPERATORS

        public static bool operator ==(Person p1, Person p2) => p1.Equals(p2);
        public static bool operator !=(Person p1, Person p2) => !p1.Equals(p2);

    }

}
