using Business;
using Modules;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Windows.Forms;

namespace Presentation_WinForms
{
    public partial class ContactInfo : Form
    {
        private Contact contact = null;
        private Mode Mode = Mode.AddNew;
        public ContactInfo(int ID)
        {
            InitializeComponent();
            contact = ContactService.FindContact(ID);
            if (contact == null) Mode = Mode.AddNew;
            else Mode = Mode.Update;
        }

        private void LoadContactInfoForUpdate()
        {
            lblID.Text = contact.ID.ToString();
            txtFirstName.Text = contact.FirstName;
            txtLastName.Text = contact.LastName;
            txtEmail.Text = contact.Email;
            txtPhone.Text = contact.Phone;
            txtAddress.Text = contact.Address;
            DTPkrDateOfBirth.Value = contact.DateOfBirth;
            cmboBCountry.SelectedIndex = cmboBCountry.FindString(CountryService.FindCountry(contact.CountryID).Name);

            if (contact.ImagePath != "")
            {
                picBImage.Load(contact.ImagePath);
            }

            lnkLblRemoveImage.Visible = (contact.ImagePath != "");
        }

        private void FillComboBox()
        {
            DataTable dataTable = CountryService.CountryDataTable();
            foreach (DataRow row in dataTable.Rows)
            {
                cmboBCountry.Items.Add(row["CountryName"]);
            }
        }

        private void LoadContact()
        {
            FillComboBox();
            switch (Mode)
            {
                case Mode.AddNew:
                    lblID.Text = "???";
                    lblMainLabel.Text = "Add New Contact";
                    contact = new Contact();
                    return;
                case Mode.Update:
                    LoadContactInfoForUpdate();
                    lblMainLabel.Text = $"Edit Contact {contact.ID}";
                    return;
            }
        }

        private void ContactInfo_Load(object sender, System.EventArgs e)
        {
            LoadContact();
        }

        private void CleanForm()
        {
            lblID.Text = "";
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmboBCountry.SelectedIndex = -1;
            DTPkrDateOfBirth.Value = DateTime.Now;
        }

        private void Save()
        {
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            contact.Email = txtEmail.Text;
            contact.Phone = txtPhone.Text;
            contact.Address = txtAddress.Text;
            contact.DateOfBirth = DTPkrDateOfBirth.Value;
            contact.CountryID = CountryService.FindCountry(cmboBCountry.Text).ID;

            if (picBImage.ImageLocation != null)
                contact.ImagePath = picBImage.ImageLocation;
            else
                contact.ImagePath = "";
        }
        
        private void SaveNew()
        {
            Save();
            bool AddSuccess = ContactService.AddNewContact(contact);
            if (AddSuccess) MessageBox.Show("New Contact Saved Successfully");
            else MessageBox.Show("Failed To Add New Contact");
        }

        private void SaveUpdate()
        {
            Save();
            bool UpdateSuccess = ContactService.UpdateContact(contact.ID, contact);
            if (UpdateSuccess) MessageBox.Show("Update Contact Saved Successfully");
            else MessageBox.Show("Failed To Update Contact");
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            switch (Mode)
            {
                case Mode.AddNew:
                    SaveNew();
                    break;
                case Mode.Update:
                    SaveUpdate();
                    break;
            }
            CleanForm();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void lnkLblAddImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                picBImage.Load(selectedFilePath);
                // ...
            }
        }

        private void lnkLblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picBImage.ImageLocation = null;
            lnkLblRemoveImage.Visible = false;
        }
    }
}
