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
        private int _selectedYear;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            // Initialisieren des Startmonats und -jahres
            SelectedMonth = DateTime.Now.Month;
            SelectedYear = DateTime.Now.Year;
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

        public int SelectedYear
        {
            get => _selectedYear;
            set
            {
                if (_selectedYear != value)
                {
                    _selectedYear = value;
                    OnPropertyChanged(nameof(SelectedYear));
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public DateTime SelectedDate => new DateTime(SelectedYear, SelectedMonth, 1);

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
