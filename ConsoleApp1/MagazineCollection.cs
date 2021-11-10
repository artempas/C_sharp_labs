using System.Collections.Generic;
using System;
using System.Linq;

namespace sharp_lab_1
{ 
    public delegate TKey KeySelector<TKey>(Magazine mg);
    class MagazineCollection<TKey>
    {
        #region Fields

        private Dictionary<TKey, Magazine> _collection = new Dictionary<TKey, Magazine>();
        private KeySelector<TKey> _ks;
        
        #endregion

        #region Constructor

        public MagazineCollection(KeySelector<TKey> ks)
        {
            _ks = ks;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Adds specified amount of obj to collection with default parameters
        /// </summary>
        /// <param name="n">amount of obj</param>
        void AddDefaults(int n)
        {
            Magazine magazine = new Magazine();
            _collection.Add(_ks(magazine), magazine);
        }

        /// <summary>
        /// add list of magazines to the collection
        /// </summary>
        /// <param name="toAdd">list of magazines</param>
        void AddMagazines(Magazine[] toAdd)
        {
            foreach (var mag in toAdd)
            {
                Magazine magazine = mag as Magazine;
                _collection.Add(_ks(magazine), magazine);
            }
        }

        public override string ToString()
        {
            string ans = "";
            int cnt = 1;
            foreach (var (key, value) in _collection)
            {
                ans += cnt++.ToString() + ")\n";
                ans+=value.ToString();
            }

            return ans;
        }

        public string ToShortString()
        {
            string ans = "";
            int cnt = 1;
            foreach (var (key, value) in _collection)
            {
                ans += cnt++.ToString() + ")\n";
                ans+=value.ToShortString();
            }

            return ans;
        }
        /// <summary>
        /// Returns collection of magazines made of magazines with a specified Frequency
        /// </summary>
        /// <param name="value">Value of frequency filter</param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
        {
            return _collection.Where(pair => pair.Value[value]);
        }


        #endregion

        #region Properties

        double MaxAverageRating
        {
            get
            {
                return _collection.Values.Max(m => m.AverageArticleRating);
            }
        }

        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> GroupedByFrequency => _collection.GroupBy(mag => mag.Value.Freq);
        

        #endregion
    }
}