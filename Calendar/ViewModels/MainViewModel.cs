using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private int _selectedMonth;
        private int _selectedYear;
        private DateTime _selectedDate;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            SelectedMonth = DateTime.Now.Month;
            SelectedYear = DateTime.Now.Year;
            SelectedDate = DateTime.Now; 
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
                    OnPropertyChanged(nameof(ShownCalendarDate));
                }
            }
        }

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
                    OnPropertyChanged(nameof(ShownCalendarDate));
                }
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                    OnPropertyChanged(nameof(SelectedDay)); 
                    OnPropertyChanged(nameof(SelectedMonthText));
                    OnPropertyChanged(nameof(SelectedWeekdayText));
                }
            }
        }

        public string SelectedMonthText => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(SelectedDate.Month);

        public string SelectedWeekdayText => SelectedDate.ToString("dddd", CultureInfo.CurrentCulture); 

        public int SelectedDay => SelectedDate.Day;

        public DateTime ShownCalendarDate => new DateTime(SelectedYear, SelectedMonth, 1);

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
