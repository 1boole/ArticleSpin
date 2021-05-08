using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business.Utilities.FileHelper
{
    public class XlsxFileReader
    {
        public static void OpenXlsx(DataGridView dataGridView)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Dosyaları|*.xlsx", Multiselect = false })
            {
                Cursor.Current = Cursors.WaitCursor;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = new DataTable();
                    using (XLWorkbook workBook = new XLWorkbook(ofd.FileName))
                    {
                        bool isFirstRow = true;
                        var rows = workBook.Worksheet(1).RowsUsed();
                        foreach (var row in rows)
                        {
                            if (isFirstRow)
                            {
                                foreach (IXLCell cell in row.Cells())
                                {
                                    dt.Columns.Add(cell.Value.ToString());
                                    isFirstRow = false;
                                }
                            }
                            else
                            {
                                dt.Rows.Add();
                                int i = 0;
                                foreach (IXLCell cell in row.Cells())
                                {
                                    dt.Rows[dt.Rows.Count - 1][i++] = cell.Value.ToString();
                                }
                            }
                        }
                    }
                    dataGridView.DataSource = dt.DefaultView;
                    Cursor.Current = Cursors.Default;
                }

            }
        }

        public string Search(DataGridView data, string searchValue)
        {
            try
            {
                DataView dv = data.DataSource as DataView;

                if (dv != null)
                {
                    dv.RowFilter = "FirstValue='" + searchValue + "'";
                    if (dv.RowFilter== "FirstValue='" + searchValue + "'")
                    {
                        if (dv.Count < 1)
                        {
                            dv.RowFilter = string.Empty;
                            return searchValue;
                        }
                        else
                        {

                            if (data.Rows[0].Cells[1].Value != null)
                            {
                                string outputValue = data.Rows[0].Cells[1].Value.ToString();
                                dv.RowFilter = string.Empty;
                                return outputValue;

                            }
                            else
                            {
                                dv.RowFilter = string.Empty;
                                return searchValue;

                            }
    ;
                        }
                    }
                    else
                        return "kontrole girmedi";
                }
                else { return "tablo boş"; }

            }
            catch (Exception ex)
            {
                MessageBox.Show("hata: " + ex);
                return "hata mesajı: " + ex;
            }


        }
    }
}
