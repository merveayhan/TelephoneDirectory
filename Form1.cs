using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelephoneDirectory.Model.DAL.ORM.Context;
using TelephoneDirectory.Model.DAL.ORM.Entity;

namespace TelephoneDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProjectContext db = new ProjectContext();
        public void TextBoxEraser()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox3.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox4.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        public void AddUserTakeList()
        {
            dataGridView1.DataSource = db.AppUsers.Where(x => x.Status == Model.DAL.ORM.Enum.Status.Active || x.Status == Model.DAL.ORM.Enum.Status.Update).ToList();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AppUser appuser = new AppUser();
            appuser.FirstName = txtAddFirst.Text;
            appuser.LastName = txtAddLast.Text;
            appuser.Phone = maskedTextBox1.Text;
            db.AppUsers.Add(appuser);
            db.SaveChanges();

            AddUserTakeList();
            TextBoxEraser();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            AddUserTakeList();
        }
        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            txtUpdateFirst.Text = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
            txtUpdateLast.Text = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
            txtDeleteUser.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AppUser appuser = db.AppUsers.FirstOrDefault(x => x.ID == id);
            appuser.FirstName = txtUpdateFirst.Text;
            appuser.LastName = txtUpdateLast.Text;
            appuser.Phone = maskedTextBox2.Text;
            appuser.Status = Model.DAL.ORM.Enum.Status.Update;
            db.SaveChanges();

            AddUserTakeList();
            TextBoxEraser();
        }

      

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AppUser appuser = db.AppUsers.FirstOrDefault(x => x.ID == id);
            appuser.Status = Model.DAL.ORM.Enum.Status.Delete;
            db.SaveChanges();

            AddUserTakeList();
            TextBoxEraser();
        }
        public void UserFind()
        {
            dataGridView1.DataSource = db.AppUsers.ToList().Where(x => x.FirstName.ToLower().Contains(txtFullName.Text.ToLower())&&x.Status!=Model.DAL.ORM.Enum.Status.Delete).OrderBy(x=>x.FullName).Select(y => new
            {
                y.FullName,
                y.ID,
                y.FirstName,
                y.LastName,
                y.Phone,
                y.AddDate,
                y.UpdateDate,
                y.DeleteDate,
                y.Status
            }).ToList();

        }

        private void btnFullName_Click(object sender, EventArgs e)
        {
            UserFind();
           
        }
    }
}
