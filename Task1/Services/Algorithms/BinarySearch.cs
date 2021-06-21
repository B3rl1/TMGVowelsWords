using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	//Класс, представляющий алгоритм бинарного поиска. Используется для поиска вхождения символа в набор гласных букв.
	static class BinarySearch
	{
		public static bool StartSearch(char tmp, char[] pattern, int firstIndex, int lastIndex)
		{
			if (firstIndex > lastIndex)
			{
				return false;
			}

			var middle = (firstIndex + lastIndex) / 2;
			var middleChar = pattern[middle];

			if (middleChar == tmp)
			{
				return true;
			}
			else
			{
				if (middleChar > tmp)
				{
					return StartSearch(tmp, pattern, firstIndex, middle - 1);
				}
				else
				{
					return StartSearch(tmp, pattern, middle + 1, lastIndex);
				}
			}
		}
	}
}
