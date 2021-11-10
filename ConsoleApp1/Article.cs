using System;
using System.Collections.Generic;
using System.Text;

namespace sharp_lab_1
{
    public class Article : IRateAndCopy, IComparable, IComparer<Article>
    {
        #region Fields

        public Person Author;

        public string Name;

        public double Rating { get; }


        #endregion


        #region Constructors

        

        
        
        public Article(Person authorValue, string nameValue, double ratingValue)
        {
            Author = authorValue;
            Name = nameValue;
            Rating = ratingValue;

        }
        public Article() : this(new Person(),"Article name",0.0)
        { }
        #endregion


        #region Methods

        /// <summary>
        /// Compares two objects by authors Surname
        /// </summary>
        /// <param name="x">first object</param>
        /// <param name="y">second object</param>
        /// <returns></returns>
        public int Compare(Article x, Article y)
        {
            if (x == null && y == null) return 0;
            else if (x == null) return -1;
            else if (y == null) return 1;
            return x.Author.Surname.CompareTo(y.Author.Surname);
        }

        /// <summary>
        /// Compares by article name
        /// </summary>
        /// <param name="obj">object to compare with</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Article compare = obj as Article;

            if (compare == null) throw new ArgumentException($"Unable to compare, object isn't Article");
            else return this.Name.CompareTo(compare.Name);
        }
        
        public override bool Equals(object obj)
        {
            Article o = obj as Article;
            return (o.Author == Author && o.Name == Name && o.Rating == Rating);
        }
        public object DeepCopy() => new Article(new Person(Author.Name,Author.Surname,Author.Birthday), Name, Rating);

        public override string ToString()
        {
            return Author.ToString() + " " + Name + " " + Rating;
        }
        #endregion
    }
    
    
    class ArticleComparerByRate : IComparer<Article>
    {
        public int Compare(Article x, Article y)
        {
            if (x == null && y == null) return 0;
            else if (x == null) return -1;
            else if (y == null) return 1;
            return x.Rating.CompareTo(y.Rating);
        }
    }
}
