using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;


namespace sharp_lab_1
{
    [Serializable]

    public enum Frequency
    {
        Weekly = 0,
        Monthly = 1,
        Yearly = 2
    };

    public delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);

    class Program
    {
        static void Main(string[] args)
        {
            #region lab5

            var m = new Magazine(Frequency.Yearly, "Doesn't really matter", new DateTime(1969, 6, 9), 69);
            m.AddArticles(new Article());

            //Console.WriteLine("Source elements:");
            //Console.WriteLine(m);

            var mCopy = m.DeepCopy();
            //Console.WriteLine("Copied element:");
            //Console.WriteLine(mCopy);

            Console.WriteLine("Enter filename: ");
            string filename;
            do
            {
                filename = Console.ReadLine();
            } while (filename.Length < 1);

            var fi = new FileInfo(filename);
            if (fi.Exists)
            {
                mCopy.Load(filename);
                Console.WriteLine("Loaded object:");
                Console.WriteLine(mCopy);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such file in this directory!");
                fi.Create().Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File was created");
                Console.ResetColor();
            }

            mCopy.AddFromConsole();
            mCopy.Save(filename);
            Console.WriteLine(mCopy);

            Magazine.Load(filename, mCopy);
            Console.WriteLine("\nAdd one more article:");
            mCopy.AddFromConsole();
            Console.WriteLine("Final version:");
            Console.WriteLine(mCopy);
            Magazine.Save(filename, mCopy);

            #endregion

            #region lab4

            // KeySelector<String> selector = magazine => magazine.GetHashCode().ToString();
            // MagazineCollection<string> mgCollection = new MagazineCollection<string>(selector);
            // mgCollection.CollectionName = "Magazine Collection";
            //
            // Magazine m1 = new Magazine();
            // Magazine m2 = new Magazine( Frequency.Monthly,"Some Name" ,new DateTime(1970,1,1), 999_999);
            // Magazine m3 = new Magazine(Frequency.Monthly,"New name",new DateTime(1980,1,1), 999_999);
            //
            // Listener listener = new Listener();
            // // changes in collections
            // mgCollection.MagazineChanged += listener.NewEntryForCollection; 
            //
            // // changes in properties
            // //m1.PropertyChanged += listener.NewEntryForProperty;
            // //m2.PropertyChanged += listener.NewEntryForProperty;
            //
            // // 1. Add new elements
            // mgCollection.AddMagazine(m1);
            // mgCollection.AddMagazine(m2);
            //
            // // 2. Change elements properties
            // m1.Date = new DateTime(2000, 1,1);
            // m1.Printing= 999;
            //
            // // 3. Replacing element
            // mgCollection.Replace(m2, m3);
            //
            // // 4. Change properties of excluded element
            // m2.Printing = 10;
            //
            // Console.WriteLine("\n\n             Changes:\n");
            // Console.WriteLine(listener);
            //

            #endregion

            //#region lab3

            // #region init
            //
            // Random rnd = new Random();
            // Magazine mag = new Magazine(Frequency.Monthly, "Пятёрочка", new DateTime(2021, 10, 26), 69);
            // Person[] persons =
            // {
            //     new Person("Lawrence", " Thomas", new DateTime(1975, 04, 26)),
            //     new Person("Larry", "Patterson", new DateTime(1957, 8, 30)),
            //     new Person("Beverly", "Kelly", new DateTime(1983, 7, 25)),
            //     new Person("Kathleen", "Anderson", new DateTime(1935, 3, 15)),
            //     new Person("Lillian", "Martin", new DateTime(rnd.Next(1950, 2003), rnd.Next(1, 12), rnd.Next(1, 31))),
            //     new Person("Aaron", "Evans", new DateTime(rnd.Next(1950, 2003), rnd.Next(1, 12), rnd.Next(1, 31))),
            //     new Person("Tina", "Taylor", new DateTime(rnd.Next(1950, 2003), rnd.Next(1, 12), rnd.Next(1, 31))),
            //     new Person("Tina", "Taylor", new DateTime(rnd.Next(1950, 2003), rnd.Next(1, 12), rnd.Next(1, 31))),
            //     new Person("Janice", "Morgan", new DateTime(rnd.Next(1950, 2003), rnd.Next(1, 12), rnd.Next(1, 31))),
            //     new Person("Judy", "Hall", new DateTime(rnd.Next(1950, 2003), rnd.Next(1, 12), rnd.Next(1, 31))),
            //     new Person("Judy", "Hall", new DateTime(rnd.Next(1950, 2003), rnd.Next(1, 12), rnd.Next(1, 31))),
            //     new Person("Evelyn", "Johnson", new DateTime(rnd.Next(1950, 2003), rnd.Next(1, 12), rnd.Next(1, 31))),
            // };
            // Article[] articles =
            // {
            //     new Article(persons[rnd.Next(9)], "How face masks affect young children", rnd.Next(4)+rnd.NextDouble()),
            //     new Article(persons[rnd.Next(9)], "Why \"Agents of Doom\" threaten the world",
            //         rnd.Next(4)+rnd.NextDouble()),
            //     new Article(persons[rnd.Next(9)], "Scotland's experiment to value nature", rnd.Next(4)+rnd.NextDouble()),
            //     new Article(persons[rnd.Next(9)], "A better use for half Earth's land?", rnd.Next(4)+rnd.NextDouble()),
            //     new Article(persons[rnd.Next(9)], "Can you grow coffee at home?", rnd.Next(4)+rnd.NextDouble()),
            //     new Article(persons[rnd.Next(9)], "America's greatest source of emissions", rnd.Next(4)+rnd.NextDouble()),
            //     new Article(persons[rnd.Next(9)], "Do we really need third vaccine doses?", rnd.Next(4)+rnd.NextDouble()),
            //     new Article(persons[rnd.Next(9)], "Should young kids get the Covid-19 jab?", rnd.Next(4)+rnd.NextDouble()),
            //     new Article(persons[rnd.Next(9)], "The unexpected benefits of tiger sharks", rnd.Next(4)+rnd.NextDouble()),
            //     new Article(persons[rnd.Next(9)], "Costa Rica's answer to 'range anxiety'", rnd.Next(4)+rnd.NextDouble()),
            // };
            // Person[] editors_to_add = new Person[5];
            // int i = 0;
            // while (i < editors_to_add.Length)
            // {
            //     int j = rnd.Next(9);
            //     if (Array.IndexOf(editors_to_add, persons[j]) != -1) continue;
            //     editors_to_add[i++] = persons[j];
            // }
            // #endregion
            //
            // #region sort
            //
            // mag.AddArticles(articles);
            // mag.AddEditors(editors_to_add);
            // mag.PrintArticles();
            // mag.SortArticlesByTitle();
            // Console.ForegroundColor = ConsoleColor.Red;
            // Console.WriteLine("Sorted by title");
            // Console.ResetColor();
            // mag.PrintArticles();
            // Console.ForegroundColor = ConsoleColor.Red;
            // Console.WriteLine("Sorted by author's surname");
            // Console.ResetColor();
            // mag.SortArticlesByAuthorSurname();
            // mag.PrintArticles();
            // Console.ForegroundColor = ConsoleColor.Red;
            // Console.WriteLine("Sorted by rating");
            // Console.ResetColor();
            // mag.SortArticlesByRating();
            // mag.PrintArticles();
            // #endregion
            //
            // #region testcollections
            //
            // int size = -1;
            // Console.ForegroundColor = ConsoleColor.White;
            // Console.Write("Size of collection: ");
            // Console.ResetColor();
            // while (!int.TryParse(Console.ReadLine(), out size) || size < 0)
            // {
            //     Console.ForegroundColor = ConsoleColor.Red;
            //     Console.WriteLine("Incorrect number, try again:");
            //     Console.ResetColor();
            // }
            //
            // GenerateElement<Edition, Magazine> generatorFunc = delegate(int j)
            // {
            //     try
            //     {
            //         var key = new Edition("Edition"+j.ToString(), new DateTime(j%9999+1, (j % 12)+1, 1 + (j % 28)), j*j);
            //         var value = new Magazine((Frequency)(j%3), "Mag"+j.ToString(), new DateTime(j%9999+1 , 1+ j % 12, 1 + j %28), j);
            //         return new KeyValuePair<Edition, Magazine>(key, value);
            //
            //     }
            //     catch (Exception e)
            //     {
            //         Console.ForegroundColor = ConsoleColor.Red;
            //         Console.WriteLine(j);
            //         Console.WriteLine(e);
            //         throw;
            //     }
            //     
            // };
            // TestCollections<Edition, Magazine>
            //     collections = new TestCollections<Edition, Magazine>(size, generatorFunc);
            // Console.ForegroundColor = ConsoleColor.Blue;
            // Console.WriteLine("String List:");
            // collections.SearchStringList();
            // Console.WriteLine("____________________________________________");
            // Console.ForegroundColor = ConsoleColor.Magenta;
            // Console.WriteLine("TList");
            // collections.SearchTList();
            // Console.WriteLine("____________________________________________");
            // Console.ForegroundColor = ConsoleColor.Cyan;
            // Console.WriteLine("String dict by key");
            // collections.SearchStringDictByKey();
            // Console.WriteLine("____________________________________________");
            // Console.ForegroundColor = ConsoleColor.Yellow;
            // Console.WriteLine("String dict by value");
            // collections.SearchStringDictByValue();
            // Console.WriteLine("____________________________________________");
            // Console.ForegroundColor = ConsoleColor.Blue;
            // Console.WriteLine("TDict by key");
            // collections.SearchTDictByKey();
            // Console.WriteLine("____________________________________________");
            // Console.ForegroundColor = ConsoleColor.Magenta;
            // Console.WriteLine("TDict by value");
            // collections.SearchTDictByValue();
            //
            // #endregion
            //
            //
            // #endregion

            #region lab2

            //
            //
            // #region task1
            //
            //
            //
            //
            // Console.WriteLine("TASK #1");
            // Edition first = new Edition("NatGeo", new DateTime(2002,07,08),69);
            // Edition second = new Edition("NatGeo", new DateTime(2002,07,08),69);
            // Console.WriteLine("First "+first.ToString());
            // Console.WriteLine("Second "+second.ToString());
            // Console.WriteLine("References are equal: "+(ReferenceEquals(first,second)));
            // Console.WriteLine("Objects are equal: "+(first == second));
            // Console.WriteLine("First hash: "+first.GetHashCode());
            // Console.WriteLine("Second hash: "+second.GetHashCode());
            // #endregion
            //
            // #region task2
            //
            // //----------------------------------------Task 2--------------------------------------------------
            //
            // Console.WriteLine("2-------------------------------------------------------------------------------");
            //
            //
            // try
            // {
            //     first.Printing = -1;
            // }
            // catch (InvalidDataException e)
            // {
            //     Console.WriteLine(e);
            // }
            //
            // #endregion
            //
            // #region task3
            //
            // //----------------------------------------Task 3--------------------------------------------------
            // Console.WriteLine("3-------------------------------------------------------------------------------");
            // Magazine m = new Magazine();
            // Article [] art = new Article[5];
            // art[0] = new Article(new Person("Name","Surname",new DateTime(2000,01,01)),"Single",1.1);
            // art[1] = new Article(new Person(), "Double", 2.2);
            // art[2] = new Article(new Person(), "Triple", 3.3);
            // art[3] = new Article(new Person("Name2", "Surname2", new DateTime(2000, 01, 01)), "Quadrouple", 4.4);
            // art[4] = new Article(new Person(), "Quintuple", 5.5);
            // Person[] editors = new Person[5];
            // editors[0] = new Person();
            // editors[1] = new Person();
            // editors[2] = new Person("Name3", "Surname3", new DateTime(2000, 01, 01));
            // editors[3] = new Person();
            // editors[4] = new Person();
            // m.AddArticles(art);
            // m.AddEditors(editors);
            // Console.WriteLine(m.ToString());
            // #endregion
            //
            // #region task4
            //
            // //----------------------------------------Task 4--------------------------------------------------
            // Console.WriteLine("4-------------------------------------------------------------------------------");
            //
            // Console.WriteLine(m.Edition);
            // #endregion
            //
            // #region task5
            //
            // //----------------------------------------Task 5--------------------------------------------------
            // Console.WriteLine("5-------------------------------------------------------------------------------");
            //
            // Magazine m2 = m.DeepCopy() as Magazine;
            // m.Name = "ANOTHER MAGAZINE";
            // Console.WriteLine($"Original:\n {m.ToShortString()}\n\nCopy:\n{m2.ToShortString()}");
            // #endregion
            //
            // #region task6
            //
            // //----------------------------------------Task 6--------------------------------------------------
            // Console.WriteLine("6-------------------------------------------------------------------------------");
            //
            // foreach (var article in m.GetEnumeratorByRating(3))
            // {
            //     Console.WriteLine(article.ToString());
            // }      
            // #endregion
            //
            // #region task7
            //
            // //----------------------------------------Task 7--------------------------------------------------
            // Console.WriteLine("7-------------------------------------------------------------------------------");
            //
            // foreach (var article in m.GetEnumeratorByName("r"))
            // {
            //     Console.WriteLine(article.ToString());
            // }
            // #endregion
            //
            // #region task8
            //
            // //----------------------------------------Task 8--------------------------------------------------
            // Console.WriteLine("8-------------------------------------------------------------------------------");
            //
            // foreach (var article in m)
            // {
            //     Article a = article as Article;
            //     Console.WriteLine(a);
            // }
            // #endregion
            //
            // #region task9
            //
            // //----------------------------------------Task 9--------------------------------------------------
            // Console.WriteLine("9-------------------------------------------------------------------------------");
            //
            // foreach (var article in m.GetEnumertorAuthorIsEditor())
            // {
            //     Article a = article as Article;
            //     Console.WriteLine(a);
            // }
            // #endregion
            //
            // #region task10
            //
            // //----------------------------------------Task 10--------------------------------------------------
            // Console.WriteLine("10-------------------------------------------------------------------------------");
            // foreach(var ed in m.GetEnumertorEditorIsNotAuthor())
            // {
            //     Person editor = ed as Person;
            //     Console.WriteLine(editor);
            // }       
            // #endregion

            #endregion

            #region Lab1

            // Magazine mag = new Magazine();
            // Console.WriteLine("1)");
            // Console.WriteLine(mag.ToShortString());
            //
            // Console.WriteLine("2)");
            // Console.WriteLine("Weekly "+mag[Frequency.Weekly].ToString());
            // Console.WriteLine("Monthly "+mag[Frequency.Monthly].ToString());
            // Console.WriteLine("Yearly "+mag[Frequency.Yearly].ToString());
            //
            // Console.WriteLine("3)");
            // mag.MagazineName = "New";
            // mag.Freq = Frequency.Monthly;
            // mag.MagazineDate = new DateTime(2022, 1, 23);
            // mag.Circulation = 112;
            // Console.WriteLine(mag.ToString());
            //
            // Console.WriteLine("4)");
            // Article[] art = new Article[2];
            // art[0] = new Article(new Person("Vadim", "Awesome", new DateTime(2000, 7, 19)), "How to be awesome?", 3.0);
            // art[1] = new Article(new Person("Bogdan", "Not awesome", new DateTime(2002, 8, 29)), "How not to be awesome", 6.0);
            // mag.AddArticles(art);
            // Console.WriteLine(mag.ToString());
            //
            // Console.WriteLine("5)");
            // Console.WriteLine("Введите число строк и столбцов, разделяя(',', '-')");
            // char[] delimiters = {',', '-'};
            // string[]t = Console.ReadLine().Split(delimiters);
            //
            //
            // int  row = int.Parse(t[0]);
            // int column = int.Parse(t[1]);
            //
            // Article[] one = new Article[row * column];
            // for (int i = 0; i < row * column; i++) one[i] = new Article();
            //
            // Article[,] two = new Article[row, column];
            // for (int i = 0; i < row; i++)
            // for (int j = 0; j < column; j++)
            //     two[i, j] = new Article();
            //
            // Article[][] step = new Article[row][];
            // for (int i = 0; i < row; i++)
            //     step[i] = new Article[column];
            // for (int i = 0; i < row; i++)
            // for (int j = 0; j < column; j++)
            //     step[i][j] = new Article();
            //
            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            // foreach (Article article in one)
            // {
            //     article.rating = 8.2;
            //     article.article = "Awesome article";
            // }
            // sw.Stop();
            // Console.WriteLine("Время выполнения операции для одномерного массива: {0}", sw.Elapsed);
            // sw.Start();
            // foreach (Article article in two)
            // {
            //     article.rating = 8.2;
            //     article.article = "Awesome article";
            // }
            // sw.Stop();
            // Console.WriteLine("Время выполнения операции для двумерного массива: {0}", sw.Elapsed);
            // sw.Start();
            // foreach (Article[] rows in step)
            // {
            //     foreach (Article article in rows)
            //     {
            //         article.rating = 8.2;
            //         article.article = "Awesome article";
            //     }
            // }
            // sw.Stop();
            // Console.WriteLine("Время выполнения операции для ступенчатого массива: {0}",sw.Elapsed);

            #endregion
        }
    }
}