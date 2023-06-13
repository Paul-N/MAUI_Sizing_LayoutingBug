using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using EvilGenius.TimeTracker.Core.Models;
using EvilGenius.TimeTracker.Core.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilGenius.TimeTracker.Core.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableGroupedCollection<DailyGroupViewModel, TimeEntry> Items { get; set; }

        public MainViewModel()
        {
            var lst = new List<TimeEntry>
            {
                new TimeEntry("Task one", new DateTime(2023, 05, 25, 09, 10, 11), new DateTime(2023, 05, 25, 09, 10, 11) + TimeSpan.FromMinutes(45)),
                new TimeEntry("Task two", new DateTime(2023, 05, 25, 23, 50, 11), new DateTime(2023, 05, 25, 23, 50, 11) + TimeSpan.FromMinutes(55)),
                new TimeEntry("Task tree", new DateTime(2023, 05, 26, 11, 40, 11), new DateTime(2023, 05, 26, 11, 40, 11) + TimeSpan.FromMinutes(6))
            };

            var grouped = lst.GroupBy(te => te.StartedAt.Date)
                .Select(grouping => new ObservableGroup<DailyGroupViewModel, TimeEntry>(
                    new DailyGroupViewModel
                    {
                        Day = grouping.First().StartedAt.ToShortDateString(),
                        TimeSpan = TimeSpan.FromTicks(grouping.Sum(te => (te.EndedAt - te.StartedAt).Ticks)).ToString()
                    }, grouping));

            Items = new ObservableGroupedCollection<DailyGroupViewModel, TimeEntry>(grouped);
        }
    }
}
