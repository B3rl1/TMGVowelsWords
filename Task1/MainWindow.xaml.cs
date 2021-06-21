using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task1.Models.Data;
using Task1.Models.Rules;
using Task1.Models.View;
using Task1.Services;

namespace Task1
{
	public partial class MainWindow : Window
	{
		private HttpService _httpService;
		private BindingList<TextView> _data;
		private StringId _stringIdView;
		static SemaphoreSlim sem = new SemaphoreSlim(1, 1);

		public MainWindow()
		{
			InitializeComponent();
			ConfigureApp();
		}

		//Базовая настройка приложения.
		//Создание объектов StringIdView и привязка к элементам а также объекта BindingList<TextView>.
		private void ConfigureApp()
		{
			_httpService = new HttpService();
			_httpService.ConfigureService();

			VowelsContainer.CreatePatternVowels();

			_data = new BindingList<TextView>();

			_stringIdView = new StringId();
			StringIdRule.OnValidStateChangeEvent += valid =>
			{
				ButtonCount.IsEnabled = valid;
			};
			TextBoxId.DataContext = _stringIdView;
			ButtonCount.DataContext = _stringIdView;
		}

		private async void Button_Click_1(object sender, RoutedEventArgs e)
		{
			List<int> lists = new List<int>();
			var str = TextBoxId.Text;

			var sb = new StringBuilder();
			sb.Append(",").Append(str);

			foreach (Match num in Regex.Matches(sb.ToString(), @"(?<=[,;])[-]{0,1}[\s\d]{1,}"))
			{
				lists.Add(Convert.ToInt32(num.Value));
			}

			var distList = lists.Distinct().ToList();

			//Синхронизируем потоки, поскольку _data - разделяемый ресурс. Поэтому при неоднократном нажатии на кнопку "Подсчитать" у нас может появиться огромный список в таблице.
			//Используя семафор, я избежал данной проблемы.
			await sem.WaitAsync();
			try
			{
				_data = new BindingList<TextView>();

				for (int i = 0; i < distList.Count; i++)
				{
					Text txt = await _httpService.FetchTextFromRequest(distList[i]);
					_data.Add(new TextView(txt));
				}

				dataGrid.ItemsSource = _data.Where(textView => textView.WordsCount > 0);
				dataGrid.Items.Refresh();
			}
			finally
			{
				sem.Release();
			}
		}
	}
}
