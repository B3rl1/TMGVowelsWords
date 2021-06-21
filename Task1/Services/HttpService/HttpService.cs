using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using Task1.Models.Data;

namespace Task1.Services
{
	//Класс Http клиента. Предоставляет работу с веб сервером, получение данных по запросу.
	class HttpService
	{
		//Константая ссылка на запрос, для того чтобы нельзя было изменить ее.
		public const string RequestUri = "http://tmgwebtest.azurewebsites.net/api/textstrings";
		//Словарь с параметрами для заголовка запроса.
		private readonly Dictionary<string, string> _requestHeaderParameters = new Dictionary<string, string>
		{
			{"TMG-Api-Key", "0J/RgNC40LLQtdGC0LjQutC4IQ=="}
		};

		public readonly HttpClient Client;

		public HttpService()
		{
			Client = new HttpClient();
		}

		//Настройка Http сервиса. В данный момент здесь только добавление API-key в заголовок запроса.
		public void ConfigureService()
		{
			Client.DefaultRequestHeaders.Add("TMG-Api-Key", _requestHeaderParameters["TMG-Api-Key"]);
		}

		//Получение данных по запросу от сервера. Дальнейшая десериализация в объект типа TextJSON.
		//Если на этом этапе возникла ошибка, то программа обработает их и выдаст предупреждение.
		//Результатом выполнения данного метода - объект Text.
		public async Task<Text> FetchTextFromRequest(int id)
		{
			TextJSON textJson = new TextJSON();

			try
			{
				var stringTask = await Client.GetStreamAsync($"{RequestUri}/{id}");
				textJson = await JsonSerializer.DeserializeAsync<TextJSON>(stringTask);
				return new Text(textJson.Text);
			}
			catch (HttpRequestException e)
			{
				HttpRequestExceptionHandler.ShowExceptionMessage(e, id);
			}
			catch (Exception e)
			{
				MessageBox.Show($"Чтение строки с номером {id} вызвало ошибку.", "Ошибка получения данных");
			}

			return new Text("");
		}
	}
}
