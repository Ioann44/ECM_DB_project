using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Publishing_center
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}

/*
1.	Создайте необходимые формы для ввода информации в базу данных (созданной на предыдущих лабораторных работах), согласно предметной области своего варианта.
2.	Проверьте работу форм (введите, измените и удалите около 10 записей в каждой форме).
3.	Проверьте правильность работы обеспечения целостности данных.
4.	Обдумайте и создайте формы, которые, возможно, будут полезными для будущих пользователей вашей БД.
*/


/*
 * dotnet core 3.1
 * Microsoft.Data.SqlClient скачан через nuget
*/