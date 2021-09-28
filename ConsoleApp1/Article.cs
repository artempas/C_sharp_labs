using System;
using System.Collections.Generic;
using System.Text;

namespace shrap_lab_1
{
    class Article
    {
        public Person Author;
        public string article;
        public double rating;

        public Article(Person AuthorValue, string articleValue, double ratingValue)
        {
            Author = AuthorValue;
            article = articleValue;
            rating = ratingValue;

        }
        public Article() : this(new Person("Author name", "Author Surname", new DateTime(1970,01,01)),"Article name",0.0)
        { }

        public override string ToString()
        {
            return Author.ToString() + " " + article + " " + rating;
        }
    }
}
