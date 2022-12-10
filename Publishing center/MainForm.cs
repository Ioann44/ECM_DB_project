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
		int cntChangeText = 0;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void ChoiceTable_TextUpdate(object sender, EventArgs e)
		{
			ChoiceTableLabel.Text = (++cntChangeText).ToString();
		}
	}
}
