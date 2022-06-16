using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercisePABDBinding
{
    public partial class Form4 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exercisePABDDataSet.Staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.exercisePABDDataSet.Staff);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            txtNama.Enabled = true;
            txtNIK.Enabled = true;
            txtDivisi.Enabled = true;
            txtJK.Enabled = true;
            txtNama.Text = "";
            txtNIK.Text = "";
            txtDivisi.Text = "";
            txtJK.Text = "";
            int ctr, len;
            string codeval;
            dt = exercisePABDDataSet.Tables["staff"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["nama"].ToString();
            codeval = code.Substring(1, 3);

            btnAdd.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dt = exercisePABDDataSet.Tables["staff"];
            dr = dt.NewRow();
            dr[0] = txtNama.Text;
            dr[1] = txtNIK.Text;
            dr[2] = txtDivisi.Text;
            dr[3] = txtJK.Text;
            dt.Rows.Add(dr);
            staffTableAdapter.Update(exercisePABDDataSet);
            txtNama.Text = System.Convert.ToString(dr[0]);
            txtNIK.Enabled = false;
            txtDivisi.Enabled = false;
            txtJK.Enabled = false;
            this.staffTableAdapter.Fill(this.exercisePABDDataSet.Staff);
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtNama.Text;
            dr = exercisePABDDataSet.Tables["staff"].Rows.Find(code);
            dr.Delete();
            staffTableAdapter.Update(exercisePABDDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
