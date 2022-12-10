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
1.	�������� ����������� ����� ��� ����� ���������� � ���� ������ (��������� �� ���������� ������������ �������), �������� ���������� ������� ������ ��������.
2.	��������� ������ ���� (�������, �������� � ������� ����� 10 ������� � ������ �����).
3.	��������� ������������ ������ ����������� ����������� ������.
4.	��������� � �������� �����, �������, ��������, ����� ��������� ��� ������� ������������� ����� ��.
*/


/*
 * dotnet core 3.1
 * Microsoft.Data.SqlClient ������ ����� nuget
*/