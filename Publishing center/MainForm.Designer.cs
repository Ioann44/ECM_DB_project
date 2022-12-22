
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
			this.tableName_ComboBox = new System.Windows.Forms.ComboBox();
			this.dataTable = new System.Windows.Forms.DataGridView();
			this.uploadDataButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.exportToPdf_Button = new System.Windows.Forms.Button();
			this.YearInputField = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.YearInputField)).BeginInit();
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
			// tableName_ComboBox
			// 
			this.tableName_ComboBox.FormattingEnabled = true;
			this.tableName_ComboBox.Items.AddRange(new object[] {
            "Писатель",
            "Контракт",
            "Книга",
            "Заказчик",
            "Заказ",
            "Авторство"});
			this.tableName_ComboBox.Location = new System.Drawing.Point(12, 44);
			this.tableName_ComboBox.Name = "tableName_ComboBox";
			this.tableName_ComboBox.Size = new System.Drawing.Size(151, 28);
			this.tableName_ComboBox.TabIndex = 2;
			this.tableName_ComboBox.TextChanged += new System.EventHandler(this.ChoiceTable_TextUpdate);
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
			this.dataTable.CurrentCellChanged += new System.EventHandler(this.dataTable_CurrentCellChanged);
			this.dataTable.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataTable_UserAddedRow);
			// 
			// uploadDataButton
			// 
			this.uploadDataButton.Location = new System.Drawing.Point(528, 42);
			this.uploadDataButton.Name = "uploadDataButton";
			this.uploadDataButton.Size = new System.Drawing.Size(209, 62);
			this.uploadDataButton.TabIndex = 4;
			this.uploadDataButton.Text = "Применить изменения";
			this.uploadDataButton.UseVisualStyleBackColor = true;
			this.uploadDataButton.Click += new System.EventHandler(this.UploadData);
			// 
			// deleteButton
			// 
			this.deleteButton.BackColor = System.Drawing.Color.PeachPuff;
			this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.deleteButton.Location = new System.Drawing.Point(408, 42);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(80, 62);
			this.deleteButton.TabIndex = 5;
			this.deleteButton.Text = "Удалить выбранную строку";
			this.deleteButton.UseVisualStyleBackColor = false;
			this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
			// 
			// exportToPdf_Button
			// 
			this.exportToPdf_Button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.exportToPdf_Button.Location = new System.Drawing.Point(528, 139);
			this.exportToPdf_Button.Name = "exportToPdf_Button";
			this.exportToPdf_Button.Size = new System.Drawing.Size(209, 27);
			this.exportToPdf_Button.TabIndex = 6;
			this.exportToPdf_Button.Text = "PDF";
			this.exportToPdf_Button.UseVisualStyleBackColor = false;
			this.exportToPdf_Button.Click += new System.EventHandler(this.exportToPdf_Button_Click);
			// 
			// YearInputField
			// 
			this.YearInputField.Location = new System.Drawing.Point(408, 139);
			this.YearInputField.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
			this.YearInputField.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
			this.YearInputField.Name = "YearInputField";
			this.YearInputField.Size = new System.Drawing.Size(80, 27);
			this.YearInputField.TabIndex = 7;
			this.YearInputField.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(759, 597);
			this.Controls.Add(this.YearInputField);
			this.Controls.Add(this.exportToPdf_Button);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.uploadDataButton);
			this.Controls.Add(this.dataTable);
			this.Controls.Add(this.tableName_ComboBox);
			this.Controls.Add(this.ChoiceTableLabel);
			this.Name = "MainForm";
			this.Text = "Издательский центр";
			((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.YearInputField)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label ChoiceTableLabel;
		private System.Windows.Forms.ComboBox tableName_ComboBox;
		private System.Windows.Forms.DataGridView dataTable;
		private System.Windows.Forms.Button uploadDataButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button exportToPdf_Button;
		private System.Windows.Forms.NumericUpDown YearInputField;
	}
}

