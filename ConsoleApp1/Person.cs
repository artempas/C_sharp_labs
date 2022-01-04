using System;
using System.Collections.Generic;
using System.Text;


namespace sharp_lab_1
{
    [Serializable]

    public class Person
    {

        string _name;
        string _surname;
        DateTime _birthday;
        
        //CONSTRUCTORS
        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            _name = nameValue;
            _surname = surnameValue;
            _birthday = birthdayValue;

        }
        public Person() : this("Иван", "Иванов", new DateTime (2000, 12, 27))
        {
        }

        //PROPERTIES
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }

            set
            {
                _birthday = value;
            }
        }

        public int Year
        {
            get
            {
                return _birthday.Year;
            }
            set
            {
                _birthday = new DateTime(value, _birthday.Month, _birthday.Day);
            }
        }

        
        //METHODS
        
        public override bool Equals(object? obj)
        {
            Person p = obj as Person;
            return (_name == p._name && _surname==p._surname && p._birthday == _birthday);
        }


        public override int GetHashCode()
        {
            return _surname.GetHashCode()+_name.GetHashCode()+_birthday.GetHashCode();
        }


        public object DeepCopy() => new Person(_name, _surname, _birthday);
        

        public override string ToString()
        {
           return Name+" "+ Surname+" "+ _birthday.ToShortDateString();

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
