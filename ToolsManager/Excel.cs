﻿using System;
using System.IO;
using System.Windows.Forms;

namespace ToolsManager
{
    class Excel
    {
        #region DateGridView导出到csv格式的Excel     
        /// <summary>     
        /// 常用方法，列之间加\t，一行一行输出，此文件其实是csv文件，不过默认可以当成Excel打开。     
        /// </summary>     
        /// <remarks>     
        /// using System.IO;     
        /// </remarks>     
        /// <param name="dgv"></param>     
        public static void DataGridViewToExcelCSV(DataGridView dgv)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Execl files (*.xls)|*.xls";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = true;
            dlg.Title = "保存为Excel文件";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = dlg.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string columnTitle = "";
                try
                {
                    //写入列标题     
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (dgv.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                columnTitle += "\t";
                            }
                            columnTitle += dgv.Columns[i].HeaderText;
                        }
                    }
                    sw.WriteLine(columnTitle);

                    //写入列内容     
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        string columnValue = "";
                        for (int k = 0; k < dgv.Columns.Count; k++)
                        {
                            if (dgv.Columns[k].Visible)
                            {
                                if (k > 0)
                                {
                                    columnValue += "\t";
                                }
                                if (dgv.Rows[j].Cells[k].Value == null)
                                    columnValue += "";
                                else
                                    columnValue += dgv.Rows[j].Cells[k].Value.ToString().Trim();
                            }
                        }
                        sw.WriteLine(columnValue);
                    }
                    sw.Close();
                    myStream.Close();
                    MessageBox.Show("保存完成");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }
        #endregion
    }
}
