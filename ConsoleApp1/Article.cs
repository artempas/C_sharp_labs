using System;
using System.Collections.Generic;
using System.Text;

namespace sharp_lab_1
{
    
    class Article : IRateAndCopy
    {
        public Person author;
        public string name;
        public double rating;
        public double Rating { get; }

        
        //CONSTRUCTORS
        
        
        public Article(Person AuthorValue, string articleValue, double ratingValue)
        {
            author = AuthorValue;
            name = articleValue;
            rating = ratingValue;

        }
        public Article() : this(new Person(),"Article name",0.0)
        { }

        
        //METHODS
        
        public override bool Equals(object obj)
        {
            Article o = obj as Article;
            return (o.author == author && o.name == name && o.rating == rating);
        }
        public object DeepCopy() => new Article(new Person(author.Name,author.Surname,author.Birthday), name, rating);

        public override string ToString()
        {
            return author.ToString() + " " + name + " " + rating;
        }
    }
}
