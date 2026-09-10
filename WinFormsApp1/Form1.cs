using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public double AverageGrade { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Студент: {FullName} | Середній бал: {AverageGrade}";
        }
    }

    public partial class Form1 : Form
    {
        private readonly string filePath = "students_data.json";

        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            var studentsList = new List<Student>
            {
                new Student { Id = 101, FullName = "Іваненко Іван", AverageGrade = 85.5 },
                new Student { Id = 102, FullName = "Петренко Петро", AverageGrade = 92.0 },
                new Student { Id = 103, FullName = "Сидоренко Анна", AverageGrade = 78.3 }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(studentsList, options);
            File.WriteAllText(filePath, jsonString);

            MessageBox.Show("Дані успішно збережено у файл students_data.json!");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не знайдено! Спочатку збережіть дані.");
                return;
            }

            string jsonString = File.ReadAllText(filePath);
            var restoredStudents = JsonSerializer.Deserialize<List<Student>>(jsonString);

           
            listBox1.Items.Clear();

            if (restoredStudents != null)
            {
                foreach (var student in restoredStudents)
                {
                    listBox1.Items.Add(student);
                }
            }
        }
    }
}