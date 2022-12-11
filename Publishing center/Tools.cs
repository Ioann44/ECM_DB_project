using System;
using System.Collections.Generic;
using System.Text;

namespace Publishing_center
{
	static class Tools
	{
		public static string[][] readedTableData = new string[0][];

		//public static HashSet<string> tableNames = new HashSet<string>("Писатель Контракт Книга Заказчик Заказ Авторство".Split(" "));
		public static Dictionary<string, int[]> tableNames = new Dictionary<string, int[]>()
		{
			["Писатель"] = new int[] { 0 },
			["Контракт"] = new int[] { 1 },
			["Книга"] = new int[] { 0 },
			["Заказчик"] = new int[] { 0 },
			["Заказ"] = new int[] { 2 },
			["Авторство"] = new int[] {}
		};
	}
}
