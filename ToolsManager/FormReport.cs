﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {

        }

        private void FormReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.formReport = null;
        }

        private void listViewLeft_DoubleClick(object sender, EventArgs e)
        {
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "申购计划":
                    break;
                case "局申购汇总":
                    break;
                case "报废记录":
                    break;
                case "局报废汇总":
                    break;
                case "工作类别":
                    break;
                case "缺陷类别":
                    break;
                case "员工权限":
                    break;
            }
        }
    }
}
