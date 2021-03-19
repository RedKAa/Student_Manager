using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB03_StudentManager
{
    public partial class frmStudent : Form
    {
        bool showSearch = false;
        public frmStudent()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void stuID_TextChanged(object sender, EventArgs e)
        {

        }


        bool ValidateInput(bool IsNew)
        {
            bool valid = false;
            String name = txtStudentName.Text.Trim();
            String stuID = txtstuID.Text.Trim();
            errorProvider1.Clear();
            if (cbRole.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbRole, "Please Select Student Role");
                valid = true;
            }
            if (stuID.Length != 6)
            {
                errorProvider1.SetError(txtstuID, "Student ID must be digit 6 Number!!!");
                valid = true;
            }
            if (name.Length == 0)
            {
                errorProvider1.SetError(txtStudentName, "Please enter your name!");
                valid = true;
            }
            DateTime currDate = DateTime.Now;
            int currYear = currDate.Year;
            DateTime DateofBirth = dtpDOB.Value;
            int birthYear = DateofBirth.Year;
            if (currYear - birthYear < 18)
            {
                errorProvider1.SetError(dtpDOB,"Student must be older than 17 years old!");
                valid = true;
            }
            if (mtxPhone.MaskCompleted == false)
            {
                errorProvider1.SetError(mtxPhone,"Full digits only!");
                valid = true;
            }
            if (IsNew && IsPhoneDuplicate(true))
            {
                errorProvider1.SetError(mtxPhone, "Phone number is duplicate!");
                valid = true;
            }
            if(!IsNew && IsPhoneDuplicate(false))
            {
                errorProvider1.SetError(mtxPhone, "Phone number is duplicate!");
                valid = true;
            }
            if (IsNew && IsDuplicate() )
            {
                errorProvider1.SetError(txtstuID, "Student's ID is duplicate!");
                valid = true;
            }
            if (valid == true)
            {
                return false;
            }

            return true;
        }


        bool IsDuplicate()
        {
            for(int i = 0;i<tbStudent.Rows.Count;i++)
            {
                DataGridViewRow r = tbStudent.Rows[i];
                if (r.Cells[1].Value.Equals(txtstuID.Text) && r.Cells[0].Value.Equals(cbRole.Text))
                {
                    return true;
                }
            }
            return false;
        }

        bool IsPhoneDuplicate(bool isNew)
        {
            if (isNew) 
            { 
                for (int i = 0; i < tbStudent.Rows.Count; i++)
                {
                    DataGridViewRow r = tbStudent.Rows[i];
                    if (r.Cells[4].Value.Equals(mtxPhone.Text))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                Int32 selectedIndex = tbStudent.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                for (int i = 0; i < tbStudent.Rows.Count; i++)
                {
                    if (i != selectedIndex)
                    {
                        DataGridViewRow r = tbStudent.Rows[i];
                        if (r.Cells[4].Value.Equals(mtxPhone.Text))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        void SearchbyName()
        {
            FormResult frm = new FormResult();
            for (int i = 0; i < tbStudent.Rows.Count; i++)
            {
                DataGridViewRow r = tbStudent.Rows[i];
                if (r.Cells[2].Value.ToString().Contains(txtName.Text))
                {
                    frm.AddStudentInfo(r.Cells[0].Value.ToString(),
                    r.Cells[1].Value.ToString(), r.Cells[2].Value.ToString(),
                    r.Cells[3].Value.ToString(), r.Cells[4].Value.ToString(),
                    r.Cells[5].Value.ToString());
                }
            }
            frm.ShowDialog();
        }

        void AddNewStudent()
        {
            string gender = "";
            if (btnMale.Checked == true)
                gender = "Male";
            else if (btnFemale.Checked == true) gender = "Female";

            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(tbStudent);
            r.SetValues(cbRole.Text,txtstuID.Text,txtStudentName.Text,
                        dtpDOB.Value.ToShortDateString(),mtxPhone.Text,gender);
            tbStudent.Rows.Add(r);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbRole.SelectedIndex = -1;
            txtstuID.Clear();
            txtStudentName.Clear();
            dtpDOB.Value = DateTime.Now;
            mtxPhone.Clear();   
            btnFemale.Checked = false;
            btnMale.Checked = true;
            txtstuID.Enabled = true;
            errorProvider1.Clear();
            btnAdd.Enabled = true;
            cbRole.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput(true) == false)
            {
                DialogResult d = MessageBox.Show("Your input is incorrect ! Please try again !");
                return;
            }
            AddNewStudent();
            MessageBox.Show("Add successed!");
            txtstuID.Enabled = false;
            btnAdd.Enabled = false;
            cbRole.Enabled = false;
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            //if (ValidateInput()==false) {
            //    DialogResult d = MessageBox.Show("Your input is incorrect ! Please try again !");
            //    return;
            //}
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // saveFileDialog1.Filter = "Data files|*.dat|Text files|*.txt|Both files|*.dat;*.txt";
            DialogResult rs = saveFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(fileName);
                string Line = "";
                for (int i = 0; i < tbStudent.Rows.Count - 0; ++i)
                {
                    if (i == tbStudent.NewRowIndex)
                    {
                        break;
                    }
                    Line = "";
                    for (int j = 0; j < tbStudent.Columns.Count; ++j)
                    {
                        Line += tbStudent[j, i].Value + "_";
                    }
                    //sw.WriteLine();
                    sw.WriteLine(Line);
                }
                sw.Close();
            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Data files|*.dat|Text files|*.txt|Both files|*.dat;*.txt|All files|*.*";
            
            DialogResult rs = openFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(fileName);
                string Line = sr.ReadLine();
                tbStudent.Rows.Clear();
                while ((Line != null) && (Line != " "))
                {
                    string[] array = Line.Split('_');
                    tbStudent.Rows.Add(array);
                    Line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            FormResult frm = new FormResult();
            for (int i = 0; i < tbStudent.Rows.Count; i++)
            {
                DataGridViewRow r = tbStudent.Rows[i];
                if (r.Cells[0].Value.ToString().Equals(cbFilter.Text))
                {
                    frm.AddStudentInfo(r.Cells[0].Value.ToString(),
                    r.Cells[1].Value.ToString(), r.Cells[2].Value.ToString(),
                    r.Cells[3].Value.ToString(), r.Cells[4].Value.ToString(),
                    r.Cells[5].Value.ToString());
                }
            }
            frm.ShowDialog();
        }

        private void bthSearch_Click(object sender, EventArgs e)
        {
            SearchbyName();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            pnSearch.Visible = showSearch;
            showSearch = !showSearch;
        }

        private void tbStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            Int32 index = tbStudent.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (index > -1)
            {
                if (MessageBox.Show(this, "Are you sure to delete this record?", "Confirm Action", MessageBoxButtons.YesNo) == DialogResult.Yes)
                tbStudent.Rows.RemoveAt(index);
                MessageBox.Show("Delete successed!");
            }
            else
            {
                DialogResult d = MessageBox.Show("Please select row to delete!");
            }
        }

        private void tbStudent_Click(object sender, EventArgs e)
        {
            Int32 index = tbStudent.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (index != -1)
            {
                errorProvider1.Clear();
                cbRole.Enabled = false;
                txtstuID.Enabled = false;
                btnAdd.Enabled = false;
                DataGridViewCellCollection cells = tbStudent.Rows[index].Cells;
                cbRole.SelectedIndex = cbRole.Items.IndexOf(cells[0].Value.ToString());
                txtstuID.Text = cells[1].Value.ToString();
                txtStudentName.Text = cells[2].Value.ToString();
                dtpDOB.Value = DateTime.Parse(cells[3].Value.ToString());
                mtxPhone.Text = cells[4].Value.ToString();
                if (cells[5].Value.ToString().Contains("F"))
                {
                    btnFemale.Checked = true;
                    btnMale.Checked = false;
                }
                else
                {
                    btnMale.Checked = true;
                    btnFemale.Checked = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.ValidateInput(false))
            {
                Int32 index = tbStudent.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if(index != -1)
                {
                    if (MessageBox.Show(this, "Update this record?", "Confirm Action", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //tbStudent.BeginEdit(true);
                        DataGridViewCellCollection cells = tbStudent.Rows[index].Cells;
                        cells[0].Value = cbRole.SelectedItem.ToString();
                        cells[2].Value = txtStudentName.Text;
                        cells[3].Value = dtpDOB.Value.ToString("M/d/yyyy");
                        cells[4].Value = mtxPhone.Text;
                        cells[5].Value = btnFemale.Checked ? btnFemale.Text : btnMale.Text;
                        // tbStudent.EndEdit();
                        MessageBox.Show("Update successed!");
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
