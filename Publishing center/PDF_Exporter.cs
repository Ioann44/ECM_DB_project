using System;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Publishing_center
{
	class PDF_Exporter
	{
		public static bool WriteToPdf(in DataGridView dataTable)
		{
			if (dataTable.Rows.Count > 0)
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "PDF (*.pdf)|*.pdf";
				sfd.FileName = "Output.pdf";
				bool fileError = false;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					if (File.Exists(sfd.FileName))
					{
						try
						{
							File.Delete(sfd.FileName);
						}
						catch (IOException ex)
						{
							fileError = true;
							MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
						}
					}
					if (!fileError)
					{
						try
						{
							BaseFont courier = BaseFont.CreateFont(Environment.PathToFont, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
							Font font = new Font(courier, 12, Font.NORMAL);

							PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);
							pdfTable.DefaultCell.Padding = 3;
							pdfTable.WidthPercentage = 100;
							pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;


							foreach (DataGridViewColumn column in dataTable.Columns)
							{
								PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
								pdfTable.AddCell(cell);
							}

							foreach (DataGridViewRow row in dataTable.Rows)
							{
								foreach (DataGridViewCell cell in row.Cells)
								{
									string value = "";
									if (cell.Value is null)
									{
										break;
									}
									value = cell.Value.ToString();
									Phrase phrase = new Phrase(value, font);
									pdfTable.AddCell(phrase);
								}
							}

							using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
							{
								Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
								PdfWriter.GetInstance(pdfDoc, stream);
								pdfDoc.Open();
								pdfDoc.Add(pdfTable);
								pdfDoc.Close();
								stream.Close();
							}

							MessageBox.Show("Data Exported Successfully !!!", "Info");
						}
						catch (Exception ex)
						{
							MessageBox.Show("Error :" + ex.Message);
						}
					}
				}
			}
			return true;
		}
	}
}
