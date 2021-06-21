using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task1.Services
{
	//Класс, используется для обработки HttpRequestException исключений, которые возникают во время запроса к серверу.
	public static class HttpRequestExceptionHandler
	{
		private static string ExceptionTitle = "Ошибка запроса к серверу.";
		public static void ShowExceptionMessage(HttpRequestException exception, int id)
		{
			switch (Convert.ToInt32(exception.StatusCode.Value.ToString()))
			{
				case 418:
					MessageBox.Show(
						$"Вы слишком часто отправляете запросы к серверу, пожалуйста подождите.\nНе выполнен запрос по получению строки {id}",
						ExceptionTitle);
					break;

				default:
					MessageBox.Show(exception.Message, ExceptionTitle);
					break;
			}
		}
	}
}
