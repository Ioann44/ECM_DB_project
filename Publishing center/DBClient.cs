using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Publishing_center
{
	class DBClient
	{
		static async void AnotherMethod()
		{
			string connectionString = "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

			// Создание подключения
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				// Открываем подключение
				connection.Open();
				Console.WriteLine("Подключение открыто");
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				// если подключение открыто
				if (connection.State == ConnectionState.Open)
				{
					// закрываем подключение
					await connection.CloseAsync();
					Console.WriteLine("Подключение закрыто...");
				}
			}
			Console.WriteLine("Программа завершила работу.");
			Console.Read();
		}

		static void Main()
		{
			AnotherMethod();
		}
	}
}
