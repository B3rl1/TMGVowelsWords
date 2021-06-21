using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Models.Data;

namespace Task1.Models.View
{
	//Класс, представляет из себя информацию об тексте, который должен отобразиться в таблице.
	class TextView
	{
		public string Text { get; private set; }
		public int WordsCount { get; private set; }
		public int VowelsCount { get; private set; }

		public TextView(Text txt)
		{
			Text = txt.PlainText;
			WordsCount = txt.WordsCount;
			VowelsCount = txt.VowelsCount;
		}
	}
}
