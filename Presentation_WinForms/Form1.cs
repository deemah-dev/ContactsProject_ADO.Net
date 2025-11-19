using System;
using System.Windows.Forms;
using Business;

namespace Presentation_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            grdVContact.DataSource = ContactService.ContactsDataTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(grdVContact.CurrentRow.Cells["ContactID"].Value);
            ContactService.DeleteContact(ID);
            RefreshDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(grdVContact.CurrentRow.Cells["ContactID"].Value);
            Form form = new ContactInfo(ID);
            form.ShowDialog();
            RefreshDataGridView();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form form = new ContactInfo(-1);
            form.ShowDialog();
            RefreshDataGridView();
        }
    }
}