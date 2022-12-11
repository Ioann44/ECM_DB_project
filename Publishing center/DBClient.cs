using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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

		/// <summary>
		/// Update data in table
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="data">Array 3xNumOfCols, where first row - names of attributes, second row - source data, third row - new data</param>
		public static bool UpdateData(string tableName, string[][] data)
		{
			// insert Авторство (ID_автора, Шифр_книги) values ('1', '1');
			string command = $"update {tableName} set ";
			for (int j = 0; j < data[0].Length; j++)
			{
				if (Tools.tableNames[tableName].Contains(j))
					continue;

				string data2j = data[2][j] != null ? $"'{data[2][j]}'" : " null";
				command += $"{data[0][j]}=" + data2j + (j == data[0].Length - 1 ? ' ' : ',');
			}
			command += "where ";
			for (int j = 0; j < data[0].Length; j++)
			{
				string data1j = data[1][j].Length != 0 ? $"='{data[1][j]}'" : " is null";
				command += data[0][j].ToString() + data1j + (j < data[0].Length - 1 ? " and " : "");
			}
			command += ';';
			//Console.WriteLine(command);
			//return true;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				int changedNum = 0;
				SqlCommand sqlcommand = new SqlCommand(command, connection);
				try
				{
					changedNum = sqlcommand.ExecuteNonQuery();
				}
				catch (Exception)
				{ }
				return changedNum != 0;
			}
		}

		static void Main()
		{
			//foreach (var strArr in ReadAllData("Писатель"))
			//{
			//	string msg = String.Join(" ", strArr);
			//	Console.WriteLine(msg);
			//}
			string[][] comData = new string[3][];
			comData[0] = "attr1 attr2 attr3".Split();
			comData[1] = "src1 src2 src3".Split();
			comData[2] = "dest1 dest2 dest3".Split();
			bool res = UpdateData("Авторство", comData);
			Console.WriteLine(res);
		}
	}
}
