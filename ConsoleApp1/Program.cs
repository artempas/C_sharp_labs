using System;
using System.Diagnostics;

namespace shrap_lab_1
{
    enum Frequency { Weekly, Monthly, Yearly };
    class Program
    {
        static void Main(string[] args)
        {
            
            Magazine mag = new Magazine();
            Console.WriteLine("1)");
            Console.WriteLine(mag.ToShortString());
            
            Console.WriteLine("2)");
            Console.WriteLine("Weekly "+mag[Frequency.Weekly].ToString());
            Console.WriteLine("Monthly "+mag[Frequency.Monthly].ToString());
            Console.WriteLine("Yearly "+mag[Frequency.Yearly].ToString());
            
            Console.WriteLine("3)");
            mag.MagazineName = "New";
            mag.Freq = Frequency.Monthly;
            mag.MagazineDate = new DateTime(2022, 1, 23);
            mag.Circulation = 112;
            Console.WriteLine(mag.ToString());

            Console.WriteLine("4)");
            Article[] art = new Article[2];
            art[0] = new Article(new Person("Vadim", "Awesome", new DateTime(2000, 7, 19)), "How to be awesome?", 3.0);
            art[1] = new Article(new Person("Bogdan", "Not awesome", new DateTime(2002, 8, 29)), "How not to be awesome", 6.0);
            mag.AddArticles(art);
            Console.WriteLine(mag.ToString());
            
            Console.WriteLine("5)");
            Console.WriteLine("Введите число строк и столбцов, разделяя(',', '-')");
            char[] delimiters = {',', '-'};
            string[]t = Console.ReadLine().Split(delimiters);
            

            int  row = int.Parse(t[0]);
            int column = int.Parse(t[1]);

            Article[] one = new Article[row * column];
            for (int i = 0; i < row * column; i++) one[i] = new Article();

            Article[,] two = new Article[row, column];
            for (int i = 0; i < row; i++)
            for (int j = 0; j < column; j++)
                two[i, j] = new Article();

            Article[][] step = new Article[row][];
            for (int i = 0; i < row; i++)
                step[i] = new Article[column];
            for (int i = 0; i < row; i++)
            for (int j = 0; j < column; j++)
                step[i][j] = new Article();
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (Article article in one)
            {
                article.rating = 8.2;
                article.article = "Awesome article";
            }
            sw.Stop();
            Console.WriteLine("Время выполнения операции для одномерного массива: {0}", sw.Elapsed);
            sw.Start();
            foreach (Article article in two)
            {
                article.rating = 8.2;
                article.article = "Awesome article";
            }
            sw.Stop();
            Console.WriteLine("Время выполнения операции для двумерного массива: {0}", sw.Elapsed);
            sw.Start();
            foreach (Article[] rows in step)
            {
                foreach (Article article in rows)
                {
                    article.rating = 8.2;
                    article.article = "Awesome article";
                }
            }
            sw.Stop();
            Console.WriteLine("Время выполнения операции для ступенчатого массива: {0}",sw.Elapsed);
        }

    }
}
