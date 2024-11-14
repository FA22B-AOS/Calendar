using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CalendarApp.ViewModels;

namespace CalendarApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void lblNote_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtNote.Focus();
        }

        private void txtNote_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNote.Text) && txtNote.Text.Length > 0)
            {
                lblNote.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblNote.Visibility = Visibility.Visible;
            }
        }

        private void lblTime_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtTime.Focus();
        }

        private void txtTime_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTime.Text) && txtTime.Text.Length > 0)
            {
                lblNote.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblNote.Visibility = Visibility.Visible;
            }
        }

        private void OnMonthButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel viewModel && sender is Button button)
            {
                if (int.TryParse(button.Tag.ToString(), out int month))
                {
                    viewModel.SelectedMonth = month;

                    foreach (var child in ((StackPanel)button.Parent).Children)
                    {
                        if (child is Button btn)
                        {
                            btn.ClearValue(Button.ForegroundProperty);
                            btn.ClearValue(Button.FontWeightProperty);
                            btn.ClearValue(Button.FontSizeProperty);
                        }
                    }

                    button.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#c73f69"));
                    button.FontWeight = FontWeights.SemiBold;
                    button.FontSize = button.FontSize + 5;
                }
            }
        }

        private void OnPreviousYearClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.SelectedYear--;
                UpdateYearButtons(viewModel.SelectedYear);
            }
        }

        private void OnNextYearClick(object sender, RoutedEventArgs e)
        {

            if (DataContext is MainViewModel viewModel)
            {
                viewModel.SelectedYear++;  
                UpdateYearButtons(viewModel.SelectedYear);
            }
        }

        private void OnYearButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int selectedYear)
            {
                if (DataContext is MainViewModel viewModel)
                {
                    viewModel.SelectedYear = selectedYear;
                    UpdateYearButtons(viewModel.SelectedYear);
                }
            }
        }

        private void UpdateYearButtons(int selectedYear)
        {
            int baseYear = selectedYear - 2;
            var buttons = yearPanel.Children.OfType<Button>().ToList();

            if (buttons.Count != 7)
            {
                return;
            }

            for (int i = 1; i <= 5; i++)
            {
                int year = baseYear + i - 1;
                buttons[i].Content = year.ToString();
                buttons[i].Tag = year;
            }

            foreach (var button in buttons)
            {
                button.ClearValue(Button.ForegroundProperty);
                button.ClearValue(Button.FontWeightProperty);
            }

            var selectedButton = buttons.FirstOrDefault(b =>
            {
                if (b.Tag is int buttonYear)
                {
                    return buttonYear == selectedYear;
                }
                return false;
            });

            if (selectedButton != null)
            {
                selectedButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#c76f69"));
                selectedButton.FontWeight = FontWeights.SemiBold;
            }
        }

        private void OnCalendarSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is Calendar calendar && calendar.SelectedDate.HasValue)
            {
                var selectedDate = calendar.SelectedDate.Value;

                if (DataContext is MainViewModel viewModel)
                {
                    viewModel.SelectedDate = selectedDate;
                }
            }
        }

    }
}