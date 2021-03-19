using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB03_StudentManager
{
    public partial class FormResult : Form
    {
        public FormResult()
        {
            InitializeComponent();
        }
        public void AddStudentInfo(params String[] values)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(tbResult);
            for (int i = 0; i < r.Cells.Count; i++)
            {
                r.Cells[i].Value = values[i];
            }
            tbResult.Rows.Add(r);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
