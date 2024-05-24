using KtwAutomotiveEngineering.Blazor.Models.WorkingTime;
using KtwAutomotiveEngineering.Blazor.Shared.Dialogs;
using KtwAutomotiveEngineering.Blazor.Shared.Dialogs.ResultModels;
using MudBlazor;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KtwAutomotiveEngineering.Blazor.Pages.WorkingTime
{
    public partial class TrackWorkingTime : IDisposable
    {
        private bool _workDayHasStarted;
        private Timer? _timer;
        private TimeSpan _time;
        private MudTable<WorkTask>? _table;
        private bool _loading;

        private WorkDay _currentWorkDay = new() { WorkTasks = [] };
        private WorkTask _currentWorkTask;
        private WorkSlice _currentWorkSlice;

        private async Task StartWorkDay()
        {
            _workDayHasStarted = true;
            DateTime start = DateTime.Now;
            _currentWorkDay = new WorkDay
            {
                Start = start,
                WorkTasks = [new WorkTask {
                    Start = start,
                    WorkSlices = [new WorkSlice {
                        Start = start,
                    }],
                }]
            };

            var dialog = await DialogService.ShowAsync<EnterWorkTaskDesignationDialog>();
            var result = await dialog.Result;

            if (!result.Canceled)
            {
                _currentWorkDay.WorkTasks.First().Description = ((EnterWorkTaskDesignationDialogResult)result.Data).Description;
                _currentWorkDay.WorkTasks.First().Customer = ((EnterWorkTaskDesignationDialogResult)result.Data).Customer;
            }

            _currentWorkTask = _currentWorkDay.WorkTasks.First();
            _currentWorkSlice = _currentWorkTask.WorkSlices.First();

            StartTimer();
        }

        private void StartTimer()
        {
            SetClock(null);
            _timer = new Timer(SetClock, new AutoResetEvent(false), 0, 100);
        }

        private void SetClock(object? stateInfo)
        {
            _time = DateTime.Now - _currentWorkDay.Start;
            StateHasChanged();
        }

        private void StopWorkDay()
        {
            _workDayHasStarted = false;
            StopTimer();
        }

        private void StopTimer()
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose() => _timer?.Dispose();
    }
}
