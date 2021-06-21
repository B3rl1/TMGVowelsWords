using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Task1.Models.Data;
using Task1.Models.View;

namespace Task1.Models.Rules
{
	//Класс, который служит для валидации данных текстового поля.
	public class StringIdRule : ValidationRule
	{
		public int MinId { get; set; }
		public int MaxId { get; set; }

		//Данное события сделано для того, чтобы реализовать определенную логику, зависящую от того, есть ли ошибка ввода данных или нет.
		//В программе это используется для установки значения IsEnable кнопки, которая позволяет произвести запрос к серверу.
		public delegate void OnValidStateChange(bool isValid);
		public static event OnValidStateChange OnValidStateChangeEvent;

		//В данном методе описана все возможные варианты ввода данных. 
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			//В строке не должны присутствовать никакие символы кроме: пробелов, цифр, ',', ';' и знака минус. Если присутствуют, то возникает предупреждение.
			var count = Regex.Matches((string) value, "[^\\d\\s,;-]").Count;

			if (count > 0)
			{
				OnValidStateChangeEvent?.Invoke(false);
				return new ValidationResult(false, "Обнаружены недопустимые символы.");
			}

			string str = (string) value;
			StringBuilder strReplacedBuilder = new StringBuilder();		

			//Если строка состоит из пробелов или пустая, то возникает предупреждение
			if (String.IsNullOrWhiteSpace(str))
			{
				OnValidStateChangeEvent?.Invoke(false);
				return new ValidationResult(false, "Строка идентификаторов не может быть пустой или состоять из пробелов!");
			}

			strReplacedBuilder.Append(str.Replace(" ", ""));
			strReplacedBuilder.Insert(0, ",");

			var strCheck = strReplacedBuilder.ToString();
			
			//Если конечный символ строки не цифра, то возникает предупреждение.
			if (!Char.IsDigit(strCheck[strCheck.Length - 1]))
			{
				OnValidStateChangeEvent?.Invoke(false);
				return new ValidationResult(false, "В конце строки не должно быть разделителей");
			}

			//Использование регулярного выражения, для того, чтобы вытащить все числа удовлетворяющие требованиям. Если хоть одно найденное число, не соответствует интервалу, то возникает предупреждение.
			foreach (Match regValue in Regex.Matches(strReplacedBuilder.ToString(), @"(?<=[,;-])[-]{0,1}[\s\d]{1,}[-]{0,1}"))
			{
				if (regValue.Value[regValue.Value.Length - 1] == '-' || Convert.ToInt32(regValue.Value) < MinId || Convert.ToInt32(regValue.Value) > MaxId )
				{
					OnValidStateChangeEvent?.Invoke(false);
					return new ValidationResult(false, $"Введенный ID не входит в диапозон {MinId} до {MaxId}.");
				}
			}

			OnValidStateChangeEvent?.Invoke(true);
			return new ValidationResult(true, null);
		}
	}
}
