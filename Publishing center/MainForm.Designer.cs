
namespace Publishing_center
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ChoiceTableLabel = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.dataTable = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
			this.SuspendLayout();
			// 
			// ChoiceTableLabel
			// 
			this.ChoiceTableLabel.AutoSize = true;
			this.ChoiceTableLabel.Location = new System.Drawing.Point(12, 21);
			this.ChoiceTableLabel.Name = "ChoiceTableLabel";
			this.ChoiceTableLabel.Size = new System.Drawing.Size(141, 20);
			this.ChoiceTableLabel.TabIndex = 1;
			this.ChoiceTableLabel.Text = "Название таблицы";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Писатель",
            "Контракт",
            "Книга",
            "Заказчик",
            "Заказ",
            "Авторство"});
			this.comboBox1.Location = new System.Drawing.Point(12, 44);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(151, 28);
			this.comboBox1.TabIndex = 2;
			this.comboBox1.TextChanged += new System.EventHandler(this.ChoiceTable_TextUpdate);
			// 
			// dataTable
			// 
			this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataTable.Location = new System.Drawing.Point(12, 204);
			this.dataTable.Name = "dataTable";
			this.dataTable.RowHeadersVisible = false;
			this.dataTable.RowHeadersWidth = 51;
			this.dataTable.RowTemplate.Height = 29;
			this.dataTable.Size = new System.Drawing.Size(735, 371);
			this.dataTable.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(759, 597);
			this.Controls.Add(this.dataTable);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.ChoiceTableLabel);
			this.Name = "MainForm";
			this.Text = "Издательский центр";
			((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label ChoiceTableLabel;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.DataGridView dataTable;
	}
}

