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
    public partial class Form3 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exercisePABDDataSet.Dosen' table. You can move, or remove it, as needed.
            this.dosenTableAdapter.Fill(this.exercisePABDDataSet.Dosen);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            txtNama.Enabled = true;
            txtNIP.Enabled = true;
            txtMatkul.Enabled = true;
            txtJK.Enabled = true;
            txtNama.Text = "";
            txtNIP.Text = "";
            txtMatkul.Text = "";
            txtJK.Text = "";
            int ctr, len;
            string codeval;
            dt = exercisePABDDataSet.Tables["dosen"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["nama"].ToString();
            codeval = code.Substring(1, 3);

            btnAdd.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dt = exercisePABDDataSet.Tables["dosen"];
            dr = dt.NewRow();
            dr[0] = txtNama.Text;
            dr[1] = txtNIP.Text;
            dr[2] = txtMatkul.Text;
            dr[3] = txtJK.Text;
            dt.Rows.Add(dr);
            dosenTableAdapter.Update(exercisePABDDataSet);
            txtNama.Text = System.Convert.ToString(dr[0]);
            txtNIP.Enabled = false;
            txtMatkul.Enabled = false;
            txtJK.Enabled = false;
            this.dosenTableAdapter.Fill(this.exercisePABDDataSet.Dosen);
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtNama.Text;
            dr = exercisePABDDataSet.Tables["dosen"].Rows.Find(code);
            dr.Delete();
            dosenTableAdapter.Update(exercisePABDDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
