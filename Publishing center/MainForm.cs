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
			// reset to del collection
			Tools.rowsToDel.Clear();
			// check for correct name
			if (!Tools.tableNames.ContainsKey(tableName_ComboBox.Text))
			{
				dataTable.Columns.Clear();
				return;
			}
			Tools.readedTableData = DBClient.ReadMatrix($"select * from {tableName_ComboBox.Text};");
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
			foreach (int col_i in Tools.tableNames[tableName_ComboBox.Text])
			{
				for (int i = 0; i < n - 1; i++)
				{
					dataTable[col_i, i].Style.BackColor = Color.LightYellow;
				}
			}
		}

		private void UploadData(object sender, EventArgs e)
		{
			if (!Tools.tableNames.ContainsKey(tableName_ComboBox.Text))
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

			// insert rows
			for (int i = n; i < dataTable.Rows.Count - 1; i++)
			{
				// check if user want to remove inserted row
				if (Tools.rowsToDel.Contains(i))
				{
					continue;
				}
				// copy data to buffer
				commandData[2] = new string[commandData[0].Length];
				for (int j = 0; j < commandData[0].Length; j++)
				{
					commandData[2][j] = (string)dataTable[j, i].Value;
				}
				// add row
				DBClient.InsertData(tableName_ComboBox.Text, commandData);
			}
			// delete rows
			foreach (int rowIndex in Tools.rowsToDel)
			{
				commandData[1] = (string[])dataSrc[rowIndex + 1].Clone();
				DBClient.DeleteData(tableName_ComboBox.Text, commandData);
			}
			// scanning data and update
			for (int i = 0; i < n; i++)
			{
				// save resources if this row has been removed
				if (Tools.rowsToDel.Contains(i))
				{
					continue;
				}

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
					bool result = DBClient.UpdateData(tableName_ComboBox.Text, commandData);
				}
			}
			// update view of the table
			ChoiceTable_TextUpdate(new object(), new EventArgs());
		}

		private void DeleteButtonClick(object sender, EventArgs e)
		{
			HashSet<int> rowsToDel = new HashSet<int>();
			foreach (DataGridViewCell cell in dataTable.SelectedCells)
			{
				rowsToDel.Add(cell.RowIndex);
			}
			foreach (int rowIndex in rowsToDel)
			{
				for (int j = 0; j < dataTable.ColumnCount; j++)
				{
					dataTable[j, rowIndex].Style.BackColor = Color.LightPink;
				}
				Tools.rowsToDel.Add(rowIndex);
			}
		}

		private void dataTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
		{
			dataTable.Rows[dataTable.Rows.Count - 2].DefaultCellStyle.BackColor = Color.LightGreen;
		}

		private void dataTable_CurrentCellChanged(object sender, EventArgs e)
		{
			if (dataTable.CurrentCell is null)
			{
				return;
			}
			int col_i = dataTable.CurrentCell.ColumnIndex,
				row_i = dataTable.CurrentCell.RowIndex;
			if (Tools.tableNames[tableName_ComboBox.Text].Contains<int>(col_i) && row_i < Tools.readedTableData.Length - 1)
			{
				dataTable.Columns[col_i].ReadOnly = true;
			}
			else
			{
				dataTable.Columns[col_i].ReadOnly = false;
			}
		}
	}
}
