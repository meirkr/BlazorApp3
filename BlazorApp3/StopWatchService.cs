using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace BlazorApp3
{
    public interface IStopWatchService
    {
        IObservable<TimeSpan> GetTimeFromStart();
    }

    public class StopWatchService  : IStopWatchService
    {
        private readonly Stopwatch _stopWatch = new Stopwatch();

        public StopWatchService()
        {
            _stopWatch.Start();
        }


        #region Implementation of IObservable<out TimeSpan>

        public IObservable<TimeSpan> GetTimeFromStart()
        {
            return Observable.Interval(TimeSpan.FromSeconds(1))
                .StartWith(0)
                .Select(_ => _stopWatch.Elapsed);
        }

        #endregion
    }
}
