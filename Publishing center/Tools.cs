using System;
using System.Collections.Generic;
using System.Text;

namespace Publishing_center
{
	static class Tools
	{
		public static HashSet<string> tableNames = new HashSet<string>("Писатель Контракт Книга Заказчик Заказ Авторство".Split(" "));
	}
}
