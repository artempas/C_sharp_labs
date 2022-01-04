using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace sharp_lab_1
{
    [Serializable]

    public class Magazine : Edition
    {
        #region Fields

        private Frequency _frequency;
        private List<Person> _authors;
        private List<Article> _articles;
        private List<Person> _editors;

        #endregion

        #region CONSTRUCTORS

        public Magazine(Frequency freqValue, string nameValue, DateTime dateValue, int printingValue) : base(nameValue,
            dateValue, printingValue)
        {
            _frequency = freqValue;
            _articles = new List<Article>(0);
            _authors = new List<Person>(0);
            _editors = new List<Person>(0);
            
        }

        public Magazine() : this(Frequency.Weekly, "Magazine name", new DateTime(1970, 1, 1), 0)
        {
        }

        #endregion

        #region PROPERTIES

        public Edition Edition
        {
            get => new Edition(name, date, printing);
            set
            {
                date = value.Date;
                printing = value.Printing;
                name = value.Name;
            }
        }

        public Frequency Freq
        {
            get => _frequency;
            set => _frequency = value;
        }


        public List<Article> Articles
        {
            get => _articles;
            set => _articles = value;
        }

        public List<Person> Editors
        {
            get => _editors;
            set => _editors = value;
        }

        #endregion

        #region METHODS
        
        public static bool Save(string filename, Magazine obj)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, obj);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in static Save");
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return false;
            }
        }

        public static bool Load(string filename, Magazine obj)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    var m = (Magazine) formatter.Deserialize(fs);
                    obj.name = m.name;
                    obj.date = m.date;
                    obj.printing = m.printing;
                    obj._frequency = m._frequency;
                    
                    obj._articles.Clear();
                    obj._articles.AddRange(m._articles);
                    
                    obj._editors.Clear();
                    obj._editors.AddRange(m._editors);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void SortArticlesByTitle()
        {
            Articles.Sort(); // uses CompareTo
        }

        public void SortArticlesByAuthorSurname()
        {
            Articles.Sort(new Article()); //uses Compare
        }

        public void SortArticlesByRating()
        {
            Articles.Sort(new ArticleComparerByRate()); //uses comparator by rating
        }

        public double AverageArticleRating
        {
            get
            {
                double rate = 0;
                if (_articles == null) return 0;
                foreach (object art in _articles)
                {
                    Article article = art as Article;
                    rate += article.Rating;
                }

                return rate / _articles.Count;
            }
        }

        public IEnumerable GetEnumeratorByRating(double rating)
        {
            foreach (var article in _articles)
            {
                Article art = article as Article;
                if (art.Rating > rating)
                {
                    yield return article;
                }
            }
        }

        public IEnumerable GetEnumeratorByName(string name)
        {
            foreach (var article in _articles)
            {
                Article art = article as Article;
                if (art.Name.Contains(name))
                    yield return art;
            }
        }

        public void AddEditors(params Person[] newEditors)
        {
            _editors.AddRange(newEditors);
        }

        public void AddArticles(params Article[] newArticles)
        {
            _articles.AddRange(newArticles);
        }

        public override string ToString()
        {
            string ans = "";

            if (_articles != null)
            {
                ans += "\n| Articles:\n";
                foreach (Article art in _articles)
                {
                    ans += art.ToString() + "\n";
                }
            }

            if (_authors != null)
            {
                ans += " | Authors:\n";
                foreach (object? author in _authors)
                {
                    ans += author.ToString() + "\n";
                }
            }

            if (_editors != null)
            {
                ans += "| Editors:\n";
                foreach (object? editor in _editors)
                {
                    ans += editor.ToString() + "\n";
                }
            }

            return base.ToString() + " | " + _frequency.ToString() + ans;
        }

        public virtual string ToShortString()
        {
            return
                $"Name:{name} | Date:{date} | Printing: {printing} | frequency: {_frequency} | Authors: {_authors.Count} | Editors: {_editors.Count} | Atricles: {_articles.Count}";
        }
        
        public bool Save(string filename)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, this);
                }

                return true;
            }
            catch
            {
                return false;
            }
           
        }
        
        public bool Load(string filename)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    var m = (Magazine) formatter.Deserialize(fs);
                    name = m.name;
                    printing = m.printing;
                    _frequency = m._frequency;
                    _articles.Clear();
                    _articles.AddRange(m._articles);
                    _editors.Clear();
                    _editors.AddRange(m._editors);

                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        public new Magazine DeepCopy()
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return (Magazine) formatter.Deserialize(stream);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something goes wrong");
                Console.ResetColor();
                return new Magazine();
            }
            
        }

        
        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine(
                    "Enter article info in format:\n" +
                    "authorName-authorSurname-birthdayYear-birthdayMonth-birthdayDay-articleName-rate"
                );
                string[] words = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                var tempAuthor = new Person(words[0], words[1],
                    new DateTime(
                        Convert.ToInt32(words[2]),
                        Convert.ToInt32(words[3]),
                        Convert.ToInt32(words[4])));
                _articles.Add(
                    new Article(tempAuthor, words[5], Convert.ToDouble(words[6])));
                return true;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
                return false;
            }
            
        }
        
        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(_articles, _editors);
        }

        public IEnumerable GetEnumertorAuthorIsEditor()
        {
            foreach (var art in _articles)
            {
                Article article = art as Article;
                if (_editors.Contains(article.Author))
                {
                    yield return art;
                }
            }
        }

        public IEnumerable GetEnumertorEditorIsNotAuthor()
        {
            bool isAuthor = false;
            foreach (var ed in _editors)
            {
                isAuthor = false;
                Person editor = ed as Person;
                foreach (var art in _articles)
                {
                    Article article = art as Article;
                    if (editor == article.Author)
                    {
                        isAuthor = true;
                        break;
                    }
                }

                if (!isAuthor)
                {
                    yield return ed;
                }
            }
        }

        public void PrintArticles()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(String.Format("|{0,30}|{1,30}|{2,10}|", "Title", "Author", "Rating"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Article article in _articles)
                Console.WriteLine(String.Format("|{0,30}|{1,30}|{2,10}|", 
                    article.Name.Length <= 30 ? article.Name : article.Name.Substring(0, 30),
                    (article.Author.Name + " " + article.Author.Surname).Length <= 30 ? (article.Author.Name + " " + article.Author.Surname) : (article.Author.Name + " " + article.Author.Surname).Substring(0,30)
                    , Math.Round(article.Rating,2)));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ResetColor();


        }

        #endregion

        #region OPERATORS

        public bool this[Frequency f] => _frequency == f;

        #endregion
    }
}