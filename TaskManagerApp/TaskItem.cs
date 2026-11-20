using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskManagerApp
{
    public class TaskItem : INotifyPropertyChanged
    {
        private string _title = string.Empty;
        private bool _isCompleted;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                _isCompleted = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StatusText));
                OnPropertyChanged(nameof(CompleteButtonLabel));
            }
        }

        public string StatusText => IsCompleted ? "Виконано" : "Не виконано";
        public string CompleteButtonLabel => IsCompleted ? "Повернути" : "Виконано";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}