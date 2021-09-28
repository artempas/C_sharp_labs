using System;
using System.Collections.Generic;
using System.Text;

namespace shrap_lab_1
{
    class Magazine
    {

        private string magazine_name;
        private Frequency freq;
        private DateTime magazine_date;
        private int circulation;
        private Article[] articles;




        public Magazine(string magazine_nameValue, Frequency freqValue, DateTime magazine_dateValue, int circulationValue)
        {
            magazine_name = magazine_nameValue;
            freq = freqValue;
            magazine_date = magazine_dateValue;
            circulation = circulationValue;
            articles = null;
        }

        public Magazine(): this ("Magazine name", Frequency.Weekly, new DateTime(1970,1,1),100) 
        {

        }

        public string MagazineName
        {
            get => magazine_name;
            set => magazine_name = value;
        }
        public Frequency Freq
        {
            get => freq;
            set => freq = value;
        }
        public DateTime MagazineDate
        {
            get => magazine_date;
            set => magazine_date = value;
        }
        public int Circulation
        {
            get => circulation;
            set => circulation = value;
        }
        public Article[] ListOfArticles
        {
            get => articles;
            set => articles = value;
        }
        public double average_article_rating
        {
            get
            {
                double rate = 0;
                if (articles == null) return 0;
                foreach (var art in articles)
                {
                    rate += art.rating;
                }

                return rate / articles.Length;
            }
        }
        public bool this[Frequency f] => freq == f;

        public void AddArticles(params Article[] newArticles)
        {
            if (articles == null)
            {
                articles = newArticles;
                return;
            }
            int num = articles.Length;
            Array.Resize<Article>(ref articles, num + newArticles.Length);
            for (int i = 0; i < newArticles.Length; i++)
            {
                articles[num + i] = newArticles[i];
            }
        }
        public override string ToString()
        {
            string ans = "";
            if (articles != null)
            {
                foreach (Article art in articles)
                {
                    ans += art.ToString() + ", ";
                }
            }

            return magazine_name + " " + freq.ToString() + " " + magazine_date.ToShortDateString() + " " + circulation.ToString() + " " + ans;
        }
        public virtual string ToShortString()
        {
            return magazine_name + " " + freq.ToString() + " " + magazine_date + " " + circulation.ToString() + " " + Convert.ToString(average_article_rating);
        }

    }


}
