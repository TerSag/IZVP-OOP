using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace LibraryApp
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = "Data Source=library_db.db";

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadData();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    CREATE TABLE IF NOT EXISTS Books (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        Year INTEGER
                    );";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadData()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Title AS 'Назва', Author AS 'Автор', Year AS 'Рік видання' FROM Books";

                using (var command = new SqliteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgvBooks.DataSource = dt;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAuthor.Text) || !int.TryParse(txtYear.Text, out int year))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля коректно. Рік має бути числом.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Books (Title, Author, Year) VALUES (@title, @author, @year)";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                    command.Parameters.AddWithValue("@author", txtAuthor.Text.Trim());
                    command.Parameters.AddWithValue("@year", year);
                    command.ExecuteNonQuery();
                }
            }

            ClearFields();
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть рядок у таблиці для редагування!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAuthor.Text) || !int.TryParse(txtYear.Text, out int year))
            {
                MessageBox.Show("Будь ласка, введіть коректні дані для оновлення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["Id"].Value);

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Books SET Title = @title, Author = @author, Year = @year WHERE Id = @id";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                    command.Parameters.AddWithValue("@author", txtAuthor.Text.Trim());
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }

            ClearFields();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть рядок для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["Id"].Value);

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Books WHERE Id = @id";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }

            LoadData();
        }


        private void ClearFields()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];
                txtTitle.Text = row.Cells["Назва"].Value.ToString();
                txtAuthor.Text = row.Cells["Автор"].Value.ToString();
                txtYear.Text = row.Cells["Рік видання"].Value.ToString();
            }
        }
    }
}