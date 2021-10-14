using System;
using System.Collections;

namespace sharp_lab_1
{
	public class MagazineEnumerator:IEnumerator
	{
		ArrayList articles;
		ArrayList editors;
		int position = -1;
		public MagazineEnumerator(ArrayList articlesValue, ArrayList editorsValue)
		{
			articles = articlesValue;
			editors = editorsValue;
		}
		public object Current
		{
			get
			{
				if (position == -1 || position >= articles.Count) throw new InvalidOperationException("IndexError");
				return articles[position];
			}
		}
		public bool MoveNext()
		{
			while (true)
			{
				if (position < articles.Count - 1)
				{
					position++;
					Article art = articles[position] as Article;
					if (editors.Contains(art.author))
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
			position = -1;
		}
	}
}