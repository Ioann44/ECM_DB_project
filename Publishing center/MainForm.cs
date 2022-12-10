using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Publishing_center
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void ChoiceTable_TextUpdate(object sender, EventArgs e)
		{
			// reading data
			var data = DBClient.ReadMatrix($"select * from {comboBox1.Text};");
			// set num of rows and columns
			int n = data.Length,
				m = data[0].Length;
			dataTable.RowCount = n - 1;
			dataTable.ColumnCount = m;
			// set headers
			for (int j = 0; j < m; j++)
			{
				dataTable.Columns[j].HeaderText = data[0][j];
			}
			// set remaining data
			for (int i = 1; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					dataTable[j, i - 1].Value = data[i][j];
				}
			}
		}
	}
}
