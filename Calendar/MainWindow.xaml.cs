using Calendar.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calendar
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
    }
}