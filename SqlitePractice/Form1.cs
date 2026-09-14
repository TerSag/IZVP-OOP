using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace SqlitePractice
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = "Data Source=local_database.db";

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadDataIntoGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string commandText = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Age INTEGER
                    );";

                using (var command = new SqliteCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadDataIntoGrid()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name, Age FROM Users";

                using (var command = new SqliteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name) || !int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Будь ласка, введіть коректне ім'я та вік!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Name, Age) VALUES (@name, @age)";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.ExecuteNonQuery();
                }
            }

            txtName.Clear();
            txtAge.Clear();
            LoadDataIntoGrid();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть рядок для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Users WHERE Id = @id";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }

            LoadDataIntoGrid();
        }
    }
}