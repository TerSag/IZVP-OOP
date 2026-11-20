using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;

namespace TaskManagerApp
{
    public partial class TaskActionButton : UserControl
    {
        public static readonly StyledProperty<string> ButtonTextProperty =
            AvaloniaProperty.Register<TaskActionButton, string>(nameof(ButtonText), "Дія");

        public static readonly StyledProperty<bool> IsDangerProperty =
            AvaloniaProperty.Register<TaskActionButton, bool>(nameof(IsDanger), false);

        public string ButtonText
        {
            get => GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }

        public bool IsDanger
        {
            get => GetValue(IsDangerProperty);
            set => SetValue(IsDangerProperty, value);
        }

        public event EventHandler<RoutedEventArgs>? ActionClicked;

        public TaskActionButton()
        {
            InitializeComponent();
            UpdateAppearance();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == ButtonTextProperty)
            {
                InnerButton.Content = change.GetNewValue<string>();
            }
            else if (change.Property == IsDangerProperty)
            {
                UpdateAppearance();
            }
        }

        private void UpdateAppearance()
        {
            InnerButton.Background = IsDanger ? Brush.Parse("#DC2626") : Brush.Parse("#16A34A");
            InnerButton.Foreground = Brushes.White;
        }

        private void InnerButton_Click(object? sender, RoutedEventArgs e)
        {
            ActionClicked?.Invoke(this, e);
        }
    }
}