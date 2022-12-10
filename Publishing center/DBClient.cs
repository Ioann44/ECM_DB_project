using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Publishing_center
{
	class DBClient
	{
		static readonly string connectionString = "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=Издательский центр";

		/// <summary>
		/// Returns array of names, then every line
		/// </summary>
		/// <param name="command"></param>
		/// <returns>array of names, then rows</returns>
		public static IEnumerable<string[]> ReadData(string command)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand sqlcommand = new SqlCommand(command, connection);
				using (var reader = sqlcommand.ExecuteReader())
				{
					int colNum = reader.FieldCount;
					string[] array = new string[colNum];
					for (int i = 0; i < colNum; i++)
					{
						array[i] = reader.GetName(i);
					}
					yield return array;

					while (reader.Read())
					{
						for (int i = 0; i < colNum; i++)
						{
							array[i] = reader.GetValue(i).ToString();
						}
						yield return array;
					}
				}

			}
		}

		public static IEnumerable<string[]> ReadAllData(string tableName)
		{
			string command = $"select * from {tableName};";
			foreach (var stringArr in ReadData(command))
			{
				yield return stringArr;
			}
		}

		public static string[][] ReadMatrix(string command)
		{
			List<string[]> matrix = new List<string[]>();
			foreach (string[] stringArr in ReadData(command))
			{
				matrix.Add((string[])stringArr.Clone());
			}
			return matrix.ToArray();
		}

		static void Main()
		{
			foreach (var strArr in ReadAllData("Писатель"))
			{
				string msg = String.Join(" ", strArr);
				Console.WriteLine(msg);
			}
		}
	}
}
