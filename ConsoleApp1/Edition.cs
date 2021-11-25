using System;
using System.ComponentModel;
using System.IO;

namespace sharp_lab_1
{
    public class Edition: INotifyPropertyChanged
    {
        #region Fields
        protected string name;
        protected DateTime date;
        protected int printing;
        public event PropertyChangedEventHandler PropertyChanged; 

        #endregion

        #region CONSTRUCTORS

        

        
        
        public Edition(string nameValue, DateTime dateValue, int printingValue)
        {
            name = nameValue;
            date = dateValue;
            printing = printingValue;
        }

        public Edition() : this("Edition Name", new DateTime(1970,01,01),0)
        {}

        #endregion
        
        #region PROPERTIES
        
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("release Date"));
                
            }
        }

        public int Printing
        {
            get => printing;
            set
            {
                if (value < 0)
                {
                    throw new InvalidDataException("Тираж не может быть отрицательным");
                }

                printing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("circulation"));
            
                
            }
        }
        #endregion
        
        #region METHODS
        
        
        public override bool Equals(object? obj)
        {
            Edition e = obj as Edition;
            return (name == e.name && printing == e.printing && date.Equals(e.date));
        }
        
        public virtual object DeepCopy() => new Edition(name, date, printing);
        public override int GetHashCode()
        {
            return name.GetHashCode()+date.GetHashCode()+printing.GetHashCode();
        }

        public override string ToString()
        {
            return name+" | "+date.ToShortDateString()+" | "+printing;
        }
        #endregion
        
        #region OPERATORS
        
        
        public static bool operator ==(Edition e1, Edition e2) => e1.Equals(e2); 
        public static bool operator !=(Edition e1, Edition e2) => !e1.Equals(e2);
        #endregion
    }
}