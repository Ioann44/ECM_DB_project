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
			if (!Tools.tableNames.ContainsKey(comboBox1.Text))
			{
				dataTable.Columns.Clear();
				return;
			}
			Tools.readedTableData = DBClient.ReadMatrix($"select * from {comboBox1.Text};");
			ref string[][] data = ref Tools.readedTableData;
			// reading data
			// set num of rows and columns
			int n = data.Length,
				m = data[0].Length;
			dataTable.RowCount = n;
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
					dataTable[j, i - 1].Style.BackColor = Color.White;
				}
			}
			// add blank row for adding ability
			// enable editing for all columns
			for (int col_i = 0; col_i < m; col_i++)
			{
				dataTable.Columns[col_i].ReadOnly = false;
			}
			// disable editing for certain columns
			foreach (int col_i in Tools.tableNames[comboBox1.Text])
			{
				dataTable.Columns[col_i].ReadOnly = true;
				for (int i = 0; i < n - 1; i++)
				{
					dataTable[col_i, i].Style.BackColor = Color.LightYellow;
				}
			}
		}

		private void UploadData(object sender, EventArgs e)
		{
			if (!Tools.tableNames.ContainsKey(comboBox1.Text))
			{
				dataTable.Columns.Clear();
				return;
			}
			var dataSrc = Tools.readedTableData;
			// reading data
			string[][] commandData = new string[3][];
			commandData[0] = (string[])dataSrc[0].Clone();
			int n = dataSrc.Length - 1,
				m = dataSrc[0].Length;
			// scanning data
			for (int i = 0; i < n; i++)
			{
				bool toUpdate = false;
				commandData[1] = (string[])dataSrc[i + 1].Clone();
				commandData[2] = new string[m];
				for (int j = 0; j < m; j++)
				{
					commandData[2][j] = (string)dataTable[j, i].Value;
					if (!commandData[1][j].Equals(commandData[2][j]))
					{
						toUpdate = true;
					}
				}
				if (toUpdate)
				{
					bool result = DBClient.UpdateData(comboBox1.Text, commandData);
					ChoiceTable_TextUpdate(new object(), new EventArgs());
				}
			}
		}
	}
}
