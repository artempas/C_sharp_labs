using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace sharp_lab_1
{
    
    public class TestCollections<TKey,TValue>
    {
        private List<TKey> _tList = new List<TKey>();
        private List<string> _stringList = new List<string>();
        private Dictionary<TKey, TValue> _tDict = new Dictionary<TKey, TValue>();
        private Dictionary<string, TValue> _stringDict = new Dictionary<string, TValue>();
        private GenerateElement<TKey, TValue> _generator;

        public TestCollections(int cnt, GenerateElement<TKey, TValue> generator)
        {
            _generator = generator;
            for (var i = 0; i < cnt; i++)
            {
                var elem = _generator(i);
                _tList.Add(elem.Key);
                _stringList.Add(elem.Key.ToString());
                _tDict.Add(elem.Key,elem.Value);
                _stringDict.Add(elem.Key.ToString(),elem.Value);
            }
        }

        public void SearchTList()
        {
            var first = _tList[0];
            var middle = _tList[_tList.Count / 2];
            var last = _tList[_tList.Count - 1];
            var miss = _generator(_tList.Count);

            var watch = Stopwatch.StartNew();

            _tList.Contains(first);
            watch.Stop();
            System.Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _tList.Contains(middle);
            watch.Stop();
            System.Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _tList.Contains(last);
            watch.Stop();
            System.Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _tList.Contains(miss.Key);
            watch.Stop();
            System.Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");

        }

        public void SearchStringList()
        {
            var first = _stringList[0];
            var middle = _stringList[_stringList.Count / 2];
            var last = _stringList[_stringList.Count - 1];
            var miss = _generator(_stringList.Count);

            var watch = Stopwatch.StartNew();

            _stringList.Contains(first);
            watch.Stop();
            System.Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _stringList.Contains(middle);
            watch.Stop();
            System.Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _stringList.Contains(last);
            watch.Stop();
            System.Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _stringList.Contains(miss.Key.ToString());
            watch.Stop();
            System.Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");

        }

        public void SearchTDictByKey()
        {
            var first = _tDict.ElementAt(0).Key;
            var middle = _tDict.ElementAt(_stringList.Count / 2).Key;
            var last = _tDict.ElementAt(_tDict.Count-1).Key;
            var miss = _generator(_tDict.Count).Key;

            var watch = Stopwatch.StartNew();

            _tDict.ContainsKey(first);
            watch.Stop();
            System.Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _tDict.ContainsKey(middle);
            watch.Stop();
            System.Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _tDict.ContainsKey(last);
            watch.Stop();
            System.Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _tDict.ContainsKey(miss);
            watch.Stop();
            System.Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");
        }

        public void SearchTDictByValue()
        {
            var first = _tDict.ElementAt(0).Value;
            var middle = _tDict.ElementAt(_stringList.Count / 2).Value;
            var last = _tDict.ElementAt(_tDict.Count-1).Value;
            var miss = _generator(_tDict.Count).Value;

            var watch = Stopwatch.StartNew();

            _tDict.ContainsValue(first);
            watch.Stop();
            System.Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _tDict.ContainsValue(middle);
            watch.Stop();
            System.Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _tDict.ContainsValue(last);
            watch.Stop();
            System.Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _tDict.ContainsValue(miss);
            watch.Stop();
            System.Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");
        }

        public void SearchStringDictByKey()
        {
            var first = _stringDict.ElementAt(0).Key.ToString();
            var middle = _stringDict.ElementAt(_stringList.Count / 2).Key.ToString();
            var last = _stringDict.ElementAt(_stringDict.Count-1).Key.ToString();
            var miss = _generator(_stringDict.Count).Key.ToString();

            var watch = Stopwatch.StartNew();

            _stringDict.ContainsKey(first);
            watch.Stop();
            System.Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _stringDict.ContainsKey(middle);
            watch.Stop();
            System.Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _stringDict.ContainsKey(last);
            watch.Stop();
            System.Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _stringDict.ContainsKey(miss);
            watch.Stop();
            System.Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");
        }

        public void SearchStringDictByValue()
        {
            var first = _stringDict.ElementAt(0).Value;
            var middle = _stringDict.ElementAt(_stringList.Count / 2).Value;
            var last = _stringDict.ElementAt(_stringDict.Count-1).Value;
            var miss = _generator(_stringDict.Count).Value;

            var watch = Stopwatch.StartNew();

            _stringDict.ContainsValue(first);
            watch.Stop();
            System.Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _stringDict.ContainsValue(middle);
            watch.Stop();
            System.Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _stringDict.ContainsValue(last);
            watch.Stop();
            System.Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");
            
            watch.Restart();
            _stringDict.ContainsValue(miss);
            watch.Stop();
            System.Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");
        }
        
        
        
        



    }
}