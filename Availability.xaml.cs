using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Hosting;

namespace Mirror_Image_Photography;




public partial class Availability : ContentPage
{
    public Availability()
    {
        InitializeComponent();

        BindingContext = new CalendarViewModel();
    }
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        var name = nameEntry.Text;
        var email = emailEntry.Text;
        var phone = phoneEntry.Text;
        var subject = subjectEntry.Text;
        var message = messageEditor.Text;

        // TODO: Send the contact form data to your backend or via email

        await DisplayAlert("Thank you", "Your message has been sent.", "OK");
    }
    private void OnPrevMonthClicked(object sender, EventArgs e)
    {
        ((CalendarViewModel)BindingContext).PrevMonth();
    }

    private void OnNextMonthClicked(object sender, EventArgs e)
    {
        ((CalendarViewModel)BindingContext).NextMonth();
    }

    public class CalendarViewModel : BindableObject
    {
        private DateTime _currentDate;

        public CalendarViewModel()
        {
            _currentDate = DateTime.Now.Date;
        }

        public string CurrentMonthYear => _currentDate.ToString("MMMM yyyy");

        public ObservableCollection<CalendarDay> DaysInMonth => new ObservableCollection<CalendarDay>(GetDaysInMonth());

        private IEnumerable<CalendarDay> GetDaysInMonth()
        {
            var daysInMonth = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);

            var firstDayOfMonth = new DateTime(_currentDate.Year, _currentDate.Month, 1).DayOfWeek;

            var days = new List<CalendarDay>();

            for (int i = 0; i < (int)firstDayOfMonth; i++)
            {
                days.Add(new CalendarDay());
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                var day = new CalendarDay { DayOfMonth = i };

                if (_currentDate.Date == day.Date)
                {
                    day.BackgroundColor = Color.FromArgb("#2F4F4F");
                }

                days.Add(day);
            }

            return days;
        }

        public void PrevMonth()
        {
            _currentDate = _currentDate.AddMonths(-1);
            OnPropertyChanged(nameof(CurrentMonthYear));
            OnPropertyChanged(nameof(DaysInMonth));
        }

        public void NextMonth()
        {
            _currentDate = _currentDate.AddMonths(1);
            OnPropertyChanged(nameof(CurrentMonthYear));
            OnPropertyChanged(nameof(DaysInMonth));
        }


        public class CalendarDay
        {
            public int DayOfMonth { get; set; }
            public Color BackgroundColor { get; set; } = Color.FromArgb("#00c3ff");

            public DateTime Date
            {
                get
                {
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DayOfMonth);
                }
            }
        }

    }
    
}

