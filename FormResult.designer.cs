
namespace LAB03_StudentManager
{
    partial class FormResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbResult = new System.Windows.Forms.DataGridView();
            this.Industry_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Student_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Student_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tbResult
            // 
            this.tbResult.AllowUserToAddRows = false;
            this.tbResult.AllowUserToDeleteRows = false;
            this.tbResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Industry_code,
            this.Student_ID,
            this.Student_Name,
            this.DoB,
            this.Phone,
            this.Gender});
            this.tbResult.Location = new System.Drawing.Point(1, 13);
            this.tbResult.Margin = new System.Windows.Forms.Padding(2);
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.RowHeadersWidth = 51;
            this.tbResult.RowTemplate.Height = 29;
            this.tbResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbResult.Size = new System.Drawing.Size(799, 324);
            this.tbResult.TabIndex = 0;
            this.tbResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbResult_CellContentClick);
            // 
            // Industry_code
            // 
            this.Industry_code.HeaderText = "Major";
            this.Industry_code.MinimumWidth = 6;
            this.Industry_code.Name = "Industry_code";
            this.Industry_code.ReadOnly = true;
            this.Industry_code.Width = 125;
            // 
            // Student_ID
            // 
            this.Student_ID.HeaderText = "Student ID";
            this.Student_ID.MinimumWidth = 6;
            this.Student_ID.Name = "Student_ID";
            this.Student_ID.ReadOnly = true;
            this.Student_ID.Width = 125;
            // 
            // Student_Name
            // 
            this.Student_Name.HeaderText = "Student Name";
            this.Student_Name.MinimumWidth = 6;
            this.Student_Name.Name = "Student_Name";
            this.Student_Name.ReadOnly = true;
            this.Student_Name.Width = 125;
            // 
            // DoB
            // 
            this.DoB.HeaderText = "Day Of Birth";
            this.DoB.MinimumWidth = 6;
            this.DoB.Name = "DoB";
            this.DoB.ReadOnly = true;
            this.DoB.Width = 125;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone Number";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 125;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.MinimumWidth = 6;
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Width = 125;
            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 344);
            this.Controls.Add(this.tbResult);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormResult";
            this.Text = "FormResult";
            ((System.ComponentModel.ISupportInitialize)(this.tbResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tbResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn Industry_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Student_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Student_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
    }
}