using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task1.Models.Data
{
	//Класс представляющий текст, который получен при десериализации ответа от запроса на сервер.
	class TextJSON
	{
		[JsonPropertyName("text")]
		public string Text { get; set; }
	}
}
