using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClient.WindowsForms
{
    public partial class MainForm : Form
    {
        string URI = "http://localhost:63280";

        public MainForm()
        {
            InitializeComponent();
        }

        #region Event handlers

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex;

            DisplaySelectedRow(row);
        }

        private async void btnListStudents_Click(object sender, EventArgs e)
        {
            await LoadDataToGrid();
        }

        private async void btnAddStudent_Click(object sender, EventArgs e)
        {
            Student s = new Student
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                Age = int.Parse(txtAge.Text),
                Faculty = txtFaculty.Text
            };

            await AddStudent(s);

            await LoadDataToGrid();
        }

        private async void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            Student s = new Student
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                Address = txtAddress.Text,
                Age = int.Parse(txtAge.Text),
                Faculty = txtFaculty.Text
            };

            await UpdateStudent(s);

            await LoadDataToGrid();
        }

        private async void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtId.Text);

            await DeleteStudent(id);

            await LoadDataToGrid();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            DialogResult result = new AuthenticationForm().ShowDialog();

            if (result != DialogResult.OK)
            {
                this.Close();
            }
        }

        #endregion


        #region Methods

        private void DisplaySelectedRow(int row)
        {
            txtId.Text = dataGridView1[0, row].Value.ToString();
            txtName.Text = dataGridView1[1, row].Value.ToString();
            txtAddress.Text = dataGridView1[2, row].Value.ToString();
            txtAge.Text = dataGridView1[3, row].Value.ToString();
            txtFaculty.Text = dataGridView1[4, row].Value.ToString();
        }

        private async Task LoadDataToGrid()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI + "/api/students"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var productJsonString = await response.Content.ReadAsStringAsync();

                        dataGridView1.DataSource = JsonConvert.DeserializeObject<Student[]>(productJsonString).ToList();
                    }
                }
            }
        }

        private async Task AddStudent(Student s)
        {
            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(s);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI + "/api/students", content);
            }
        }

        private async Task UpdateStudent(Student s)
        {
            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(s);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}/{1}", URI + "/api/students", s.Id), content);
            }
        }

        private async Task DeleteStudent(int id)
        {
            using (var client = new HttpClient())
            {
                var result = await client.DeleteAsync(String.Format("{0}/{1}", URI + "/api/students", id));
            }
        }

        #endregion
    }
}
