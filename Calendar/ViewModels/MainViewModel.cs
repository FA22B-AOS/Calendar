using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private int _selectedMonth;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            // Initialisieren des Startmonats
            SelectedMonth = DateTime.Now.Month;
        }

        public int SelectedMonth
        {
            get => _selectedMonth;
            set
            {
                if (_selectedMonth != value)
                {
                    _selectedMonth = value;
                    OnPropertyChanged(nameof(SelectedMonth));
                    OnPropertyChanged(nameof(SelectedMonthText));
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public string SelectedMonthText => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(SelectedMonth);

        public DateTime SelectedDate => new DateTime(DateTime.Now.Year, SelectedMonth, 1);

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
