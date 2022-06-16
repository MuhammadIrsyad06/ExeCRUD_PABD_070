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
    public partial class Form2 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exercisePABDDataSet.Mahasiswa' table. You can move, or remove it, as needed.
            this.mahasiswaTableAdapter.Fill(this.exercisePABDDataSet.Mahasiswa);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            txtNama.Enabled = true;
            txtNIM.Enabled = true;
            txtAngk.Enabled = true;
            txtJK.Enabled = true;
            txtNama.Text = "";
            txtNIM.Text = "";
            txtAngk.Text = "";
            txtJK.Text = "";
            int ctr, len;
            string codeval;
            dt = exercisePABDDataSet.Tables["mahasiswa"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["nama"].ToString();
            codeval = code.Substring(1, 3);

            btnAdd.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dt = exercisePABDDataSet.Tables["mahasiswa"];
            dr = dt.NewRow();
            dr[0] = txtNama.Text;
            dr[1] = txtNIM.Text;
            dr[2] = txtAngk.Text;
            dr[3] = txtJK.Text;
            dt.Rows.Add(dr);
            mahasiswaTableAdapter.Update(exercisePABDDataSet);
            txtNama.Text = System.Convert.ToString(dr[0]);
            txtNIM.Enabled = false;
            txtAngk.Enabled = false;
            txtJK.Enabled = false;
            this.mahasiswaTableAdapter.Fill(this.exercisePABDDataSet.Mahasiswa);
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtNama.Text;
            dr = exercisePABDDataSet.Tables["mahasiswa"].Rows.Find(code);
            dr.Delete();
            mahasiswaTableAdapter.Update(exercisePABDDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();

        }
    }
}
