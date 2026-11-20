using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;

namespace TaskManagerApp
{
    public partial class TaskCard : UserControl
    {
        public static readonly StyledProperty<string> TaskTitleProperty =
            AvaloniaProperty.Register<TaskCard, string>(nameof(TaskTitle), string.Empty);

        public static readonly StyledProperty<string> StatusTextProperty =
            AvaloniaProperty.Register<TaskCard, string>(nameof(StatusText), "Не виконано");

        public static readonly StyledProperty<bool> IsTaskCompletedProperty =
            AvaloniaProperty.Register<TaskCard, bool>(nameof(IsTaskCompleted), false);

        public static readonly StyledProperty<string> CompleteButtonLabelProperty =
            AvaloniaProperty.Register<TaskCard, string>(nameof(CompleteButtonLabel), "Виконано");

        public string TaskTitle
        {
            get => GetValue(TaskTitleProperty);
            set => SetValue(TaskTitleProperty, value);
        }

        public string StatusText
        {
            get => GetValue(StatusTextProperty);
            set => SetValue(StatusTextProperty, value);
        }

        public bool IsTaskCompleted
        {
            get => GetValue(IsTaskCompletedProperty);
            set => SetValue(IsTaskCompletedProperty, value);
        }

        public string CompleteButtonLabel
        {
            get => GetValue(CompleteButtonLabelProperty);
            set => SetValue(CompleteButtonLabelProperty, value);
        }

        public event EventHandler<TaskItem>? ToggleCompleteRequested;
        public event EventHandler<TaskItem>? DeleteRequested;

        public TaskCard()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == TaskTitleProperty)
            {
                TitleTextBlock.Text = change.GetNewValue<string>();
            }
            else if (change.Property == StatusTextProperty || change.Property == IsTaskCompletedProperty)
            {
                StatusBadgeTextBlock.Text = $"Статус: {StatusText}";
                StatusBadgeTextBlock.Foreground = IsTaskCompleted ? Brush.Parse("#15803D") : Brush.Parse("#B45309");
                TitleTextBlock.TextDecorations = IsTaskCompleted ? TextDecorations.Strikethrough : null;
            }
            else if (change.Property == CompleteButtonLabelProperty)
            {
                CompleteActionBtn.ButtonText = change.GetNewValue<string>();
            }
        }

        private void CompleteActionBtn_ActionClicked(object? sender, RoutedEventArgs e)
        {
            if (DataContext is TaskItem task)
            {
                ToggleCompleteRequested?.Invoke(this, task);
            }
        }

        private void DeleteActionBtn_ActionClicked(object? sender, RoutedEventArgs e)
        {
            if (DataContext is TaskItem task)
            {
                DeleteRequested?.Invoke(this, task);
            }
        }
    }
}