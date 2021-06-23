using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1.Models.Data
{
	//Класс, объект которого, представляет всю информацию о тексте. Сам текст, количество слов и гласных букв.
	class Text
	{
		public readonly string PlainText;
		public readonly int WordsCount;
		public readonly int VowelsCount;

		//Данные класса могут быть установлены только в конструкторе или во время объявления.
		public Text(string plainText)
		{
			PlainText = plainText;
			if (PlainText.Length > 0)
			{
				WordsCount = CountTheWords();
				VowelsCount = CountTheVowels();
			}
			else
			{
				WordsCount = 0;
				VowelsCount = 0;
			}
		}

		//Подсчёт слов производится разделением всей строки на подстроки с помощью символа пробела и дополнительной проверкой на то, если эта строка содержиться в containPattern.
		private int CountTheWords()
		{
			string containPattern = "–—!?,;";
			var str = PlainText.Split(' ');

			return str.Where(x => !containPattern.Contains(x)).Count();
		}

		//Подсчёт гласных букв идёт с помощью просмотра всей начальной строки и поиском вхождения символа в строку VowelsContainer.PatternVowels,
		//которая представляет все возможные гласные буквы в программе, используя метод бинарного поиска.
		private int CountTheVowels()
		{
			string tmpString = PlainText.ToLower();
			int vowelsCount = 0;

			for (int i = 0; i < tmpString.Length; i++)
			{
				if (Char.IsLetter(tmpString[i]))
				{
					if (BinarySearch.StartSearch(tmpString[i], VowelsContainer.PatternVowels, 0, VowelsContainer.PatternVowels.Length))
					{
						vowelsCount++;
					}
				}
			}

			return vowelsCount;
		}
	}
}
