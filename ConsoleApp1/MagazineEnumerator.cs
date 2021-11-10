using System;
using System.Collections;
using System.Collections.Generic;

namespace sharp_lab_1
{
	public class MagazineEnumerator:IEnumerator
	{
		#region Fields
		List<Article> _articles;
		List<Person> _editors;
		int _position = -1;
		#endregion
		
		#region Constructors

		

		public MagazineEnumerator(List<Article> articlesValue, List<Person> editorsValue)
		{
			_articles = articlesValue;
			_editors = editorsValue;
		}
		
		#endregion
		
		#region Methods

		

		public object Current
		{
			get
			{
				if (_position == -1 || _position >= _articles.Count) throw new InvalidOperationException("IndexError");
				return _articles[_position];
			}
		}
		public bool MoveNext()
		{
			while (true)
			{
				if (_position < _articles.Count - 1)
				{
					_position++;
					Article art = _articles[_position] as Article;
					if (_editors.Contains(art.Author))
					{
						continue;
					}
					else
					{
						return true;
					}
				}
				else
				{
					return false;
				}
			}
		}
		public void Reset()
		{
			_position = -1;
		}
		#endregion

	}
}