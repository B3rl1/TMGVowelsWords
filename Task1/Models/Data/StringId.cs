using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Models.Data;

namespace Task1.Models.View
{
	//Класс представляющий вводимую в текстовое поле значения. Наследуется от ObservableObject, для того, чтобы программа знала, что значения изменились.
	public class StringId : ObservableObject
	{
		private string _id;

		public string Id
		{
			get { return _id; }
			set
			{
				OnPropertyChanged(ref _id, value);
			}
		}
	}
}
