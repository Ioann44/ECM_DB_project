using System;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections.Generic;

namespace Publishing_center
{
	class PDF_Exporter
	{
		static void WriteToPdf(int year, in string[] headers, in Dictionary<string, CustomerInfo> dict)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "PDF (*.pdf)|*.pdf";
			sfd.FileName = "Report.pdf";
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
						// Create font
						BaseFont arial = BaseFont.CreateFont(Environment.PathToFont, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
						Font font = new Font(arial, 12, Font.NORMAL);

						// Write to file
						using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
						{
							long allSum = 0;

							// Create file
							Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
							PdfWriter.GetInstance(pdfDoc, stream);
							pdfDoc.Open();

							// Write title
							{
								var paragraph = new Paragraph($"Прибыль от продаж книг издательского центра \"Печать\"за {year} год", font);
								paragraph.SpacingAfter = 12;
								pdfDoc.Add(paragraph);
							}

							// Write headers
							{
								PdfPTable pdfTable = new PdfPTable(headers.Length);
								pdfTable.DefaultCell.Padding = 3;
								pdfTable.WidthPercentage = 100;
								pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

								foreach (var value in headers)
								{
									pdfTable.AddCell(new Phrase(value, font));
								}
								pdfDoc.Add(pdfTable);
							}

							// Write customers info
							foreach (var (customer, customersInfo) in dict)
							{
								// Name
								{
									var paragraph = new Paragraph($"Заказчик: \"{customer}\":", font);
									paragraph.SpacingAfter = 12;
									pdfDoc.Add(paragraph);
								}

								// Table
								PdfPTable pdfTable = new PdfPTable(headers.Length);
								pdfTable.DefaultCell.Padding = 3;
								pdfTable.WidthPercentage = 100;
								pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
								foreach (var row in customersInfo.dataTable)
								{
									foreach (var value in row)
									{
										pdfTable.AddCell(new Phrase(value, font));
									}
								}
								pdfDoc.Add(pdfTable);

								// Sum
								{
									var paragraph = new Paragraph($"Итого получено от заказчика: {customersInfo.sum}", font);
									paragraph.SpacingAfter = 12;
									pdfDoc.Add(paragraph);
								}

								allSum += customersInfo.sum;
							}

							// Write total
							{
								var paragraph = new Paragraph($"Итого: {allSum}", font);
								paragraph.SetLeading(12, 2);
								pdfDoc.Add(paragraph);
							}

							pdfDoc.Close();
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

		class CustomerInfo
		{
			public List<string[]> dataTable = new List<string[]>();
			public int sum = 0;
		}

		public static void CreateReport(int year)
		{
			// Книга-0, Себестоимость-1, Цена-2, Тираж-3, Количество-4, Заказчик-5, Год-6
			string[][] db_data = DBClient.ReadMatrix(
				"select " +
				"Книга.Название as Книга, " +
				"Себестоимость_руб, " +
				"Цена_продажи_руб, " +
				"Тираж, " +
				"Количество_экземпляров_заказываемой_книги, " +
				"Заказчик.Название as Заказчик, " +
				"year(Дата_выполнения_заказа) as Год " +
				"from Книга " +
				"join Заказ on Книга.Шифр_книги = Заказ.Шифр_книги " +
				"join Заказчик on Заказ.ID = Заказчик.ID " +
				$"where year(Дата_выполнения_заказа) = {year};");

			// Headers
			// Книга-0, Себестоимость-1, Цена-2, Количество-3, Прибыль-4
			string[] headers = (string[])(
				"Название книги;" +
				"Себестоимость, руб.;" +
				"Цена продажи, руб.;" +
				"Количество экземпляров;" +
				"Прибыль от продажи книги, руб."
				).Split(';');


			Dictionary<string, CustomerInfo> customers_dict = new Dictionary<string, CustomerInfo>();
			for (int i = 1; i < db_data.Length; i++)
			{
				int edition = int.Parse(db_data[i][3]),
					cost = int.Parse(db_data[i][1]) / edition,
					price = int.Parse(db_data[i][2]) / edition,
					amount = int.Parse(db_data[i][4]),
					profit = (price - cost) * amount;

				// Initialize customers table data
				ref string customer = ref db_data[i][5];
				if (!customers_dict.ContainsKey(customer))
				{
					CustomerInfo customerInfo = new CustomerInfo();
					customers_dict[customer] = customerInfo;
				}

				CustomerInfo curInfo = customers_dict[customer];
				curInfo.dataTable.Add(new string[] { db_data[i][0], cost.ToString(), price.ToString(), amount.ToString(), profit.ToString() });

				// Update customers sum
				curInfo.sum += profit;
			}

			// Create PDF file
			WriteToPdf(year, headers, customers_dict);
		}
	}
}
