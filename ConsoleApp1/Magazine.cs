using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace sharp_lab_1
{
    class Magazine:Edition
    {
        private Frequency frequency;
        private ArrayList authors;
        private ArrayList articles;
        private ArrayList editors;


        //CONSTRUCTORS

        
        public Magazine(Frequency freqValue, string nameValue, DateTime dateValue, int printingValue): base(nameValue, dateValue, printingValue)
        {
            frequency = freqValue;
        }

        public Magazine(): this ( Frequency.Weekly, "Magazine name",new DateTime(1970,1,1),0) 
        { }

        
        //PROPERTIES
        
        
        public Edition Edition
        {
            get => new Edition(name,date,printing);
            set
            {
                date = value.Date;
                printing = value.Printing;
                name = value.Name;
            }
        }
        public Frequency Freq
        {
            get => frequency;
            set => frequency = value;
        }
        

        public ArrayList Articles
        {
            get => articles;
            set => articles = value;
        }

        public ArrayList Editors
        {
            get => editors;
            set => editors = value;
        }
        
        
        //METHODS
        
        
        public double average_article_rating
        {
            get
            {
                double rate = 0;
                if (articles == null) return 0;
                foreach (object article in articles)
                {
                    Article article_ = article as Article;
                    rate += article_.rating;
                }

                return rate / articles.Count;
            }
        }

        public IEnumerator GetEnumeratorByRating(double rating)
        {
            
            foreach (var article in articles)
            {
                Article art = article as Article;
                if (art.rating > rating)
                {
                    yield return art;
                }
            }

            
        }

        public IEnumerator GetEnumeratorByName(string name)
        {
            foreach (var article in articles)
            {
                Article art = article as Article;
                if (art.name.Contains(name))
                    yield return art;
            }
        }
        
        public void AddEditors(params Article[] newEditors)
        {
            if (editors == null)
            {
                editors = new ArrayList();
                return;
            }
            editors.AddRange(newEditors);
        }

        public void AddArticles(params Article[] newArticles)
        {
            if (articles == null)
            {
                articles = new ArrayList();
                return;
            }
            articles.AddRange(newArticles);
        }
        public override string ToString()
        {
            string ans="";
            if (articles != null)
            {
                foreach (Article art in articles)
                {
                    ans += art.ToString() + ", ";
                }
            }

            if (authors != null)
            {
                ans += " | Authors: ";
                foreach (object? author in authors)
                {
                    ans += author.ToString()+", ";
                }
            }

            return base.ToString() + " | " + frequency.ToString() + " | Articles: " + ans;
        }

        public virtual string ToShortString()
        {
            return name + " | " + date + " | " + printing + " | " + frequency;
        }

        public override object DeepCopy()
        {
            Magazine new_one = new Magazine(frequency, name, date, printing);
            new_one.articles = articles;
            new_one.authors = authors;
            new_one.editors = editors;
            return new_one;
        }
        
        
        //OPERATORS
        
        
        public bool this[Frequency f] => frequency == f;


    }


}
