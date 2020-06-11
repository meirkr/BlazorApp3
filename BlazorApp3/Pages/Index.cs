using System;
using System.Reactive.Linq;
using Microsoft.AspNetCore.Components;

namespace BlazorApp3.Pages
{
    public partial class Index : IDisposable
    {
        private string _timeAppIsUp;
        private IDisposable _disposable;

        [Inject]
        private IStopWatchService StopWatchService { get; set; }

        #region Overrides of ComponentBase

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _disposable = StopWatchService.GetTimeFromStart()
                .Select(ts => ts.ToString())
                .Subscribe(s =>
                {
                    Console.WriteLine($"Arrived: {s}");
                    _timeAppIsUp = s;
                    base.StateHasChanged();
                });
        }

        #endregion


        #region Implementation of IDisposable

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        #endregion
    }
}
