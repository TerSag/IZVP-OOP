using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using System.Linq;

namespace TaskManagerApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        public MainWindow()
        {
            InitializeComponent();
            TasksListBox.ItemsSource = Tasks;
            UpdateUncompletedCounter();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string taskText = TaskInputBox.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(taskText))
            {
                ErrorTextBlock.Text = "Помилка: Назва завдання не може бути порожньою!";
                return;
            }

            ErrorTextBlock.Text = string.Empty;
            Tasks.Add(new TaskItem { Title = taskText });

            TaskInputBox.Text = string.Empty;
            UpdateUncompletedCounter();
            StatusTextBlock.Text = $"Додано нове завдання: «{taskText}»";
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TaskItem task)
            {
                task.IsCompleted = !task.IsCompleted;
                UpdateUncompletedCounter();
                StatusTextBlock.Text = $"Статус завдання змінено на: {task.StatusText}";
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TaskItem task)
            {
                Tasks.Remove(task);
                UpdateUncompletedCounter();
                StatusTextBlock.Text = "Завдання успішно видалено";
            }
        }

        private void UpdateUncompletedCounter()
        {
            int uncompletedCount = Tasks.Count(t => !t.IsCompleted);
            CounterTextBlock.Text = $"Невиконаних завдань: {uncompletedCount}";
        }
    }
}