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
            articles = new ArrayList(0);
            authors = null;
            editors = null;
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

        public IEnumerable GetEnumeratorByRating(double rating)
        {
            
            foreach (var article in articles)
            {
                Article art = article as Article;
                if (art.rating > rating)
                {
                    yield return article;
                }
            }

            
        }

        public IEnumerable GetEnumeratorByName(string name)
        {
            foreach (var article in articles)
            {
                Article art = article as Article;
                if (art.name.Contains(name))
                    yield return art;
            }
        }
        
        public void AddEditors(params Person[] newEditors)
        {
            if (editors == null)
                editors = new ArrayList();
            editors.AddRange(newEditors);
        }

        public void AddArticles(params Article[] newArticles)
        {
            if (articles == null)
                articles = new ArrayList();

            articles.AddRange(newArticles);
        }
        public override string ToString()
        {
            string ans="";
            if (articles != null)
            {
                ans += "\n| Articles:\n";
                foreach (Article art in articles)
                {
                    ans += art.ToString() + "\n";
                }
            }

            if (authors != null)
            {
                ans += " | Authors:\n";
                foreach (object? author in authors)
                {
                    ans += author.ToString()+"\n";
                }
            }
            if (editors != null)
            {
                ans += "| Editors:\n";
                foreach (object? editor in editors)
                {
                    ans += editor.ToString() + "\n";
                }
            }

            return base.ToString() + " | " + frequency.ToString()  + ans;
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
        
        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(articles, editors);
        }

        public IEnumerable GetEnumertorAuthorIsEditor()
        {
            foreach(var art in articles)
            {
                Article article = art as Article;
                if (editors.Contains(article.author))
                {
                    yield return art;
                }
            }
        }

        public IEnumerable GetEnumertorEditorIsNotAuthor()
        {
            bool isAuthor = false;
            foreach (var ed in editors)
            {
                isAuthor = false;
                Person editor = ed as Person;
                foreach (var art in articles)
                {

                    Article article = art as Article;
                    if (editor == article.author)
                    {
                        isAuthor = true;
                        break;
                    }
                }
                if (!isAuthor) { yield return ed; }
            }
        }

        //OPERATORS


        public bool this[Frequency f] => frequency == f;


    }


}
