using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	//Класс, используется как контейнер с данными о всех гласных буквах, которые возможны в программе для корректной работы.
	static class VowelsContainer
	{
		public static char[] PatternVowels;
		private static readonly List<Dictionary<char, char>> VowelsList = new List<Dictionary<char, char>>
		{
			new Dictionary<char, char>
			{
				{'а','а'}, {'о','о'}, {'у','у'}, {'э', 'э'}, {'и','и'}, {'ы','ы'}, {'е','е'}, {'ё','ё'}, {'я', 'я'}, {'ю','ю'}, {'ӧ', 'ӧ'}, {'і', 'і'}, {'ї','ї'}
			},
			new Dictionary<char, char>
			{
				{'a','a'}, {'e','e'}, {'o','o'}, {'i', 'i'}, {'y','y'}, {'u','u'}, {'é', 'é'}, {'à', 'à'}, {'ó','ó'}, {'ú','ú'}, {'æ', 'æ'}, {'í', 'í'}, {'ä', 'ä'}, {'ö','ö'}, {'ü','ü'}, {'ø','ø'}, {'ò','ò'}, {'ê','ê'}
			}
		};

		//Метод, который формирует массив символов из всех возможных списков гласных букв, представленных в классе.
		public static void CreatePatternVowels()
		{
			List<char> compiledStr = new List<char>();

			foreach (var vowelDict in VowelsList)
			{
				foreach (var vowel in vowelDict)
				{
					compiledStr.Add(vowel.Value);
				}
			}

			//Необходимая сортировка по возрастанию.
			compiledStr.Sort();
			PatternVowels = compiledStr.ToArray();
		}
	}
}
