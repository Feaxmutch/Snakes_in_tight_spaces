using Other;
using Cysharp.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System;

namespace ViewModel
{
    public class Animator
    {
        private CancellationTokenSource _cts;

        private Animation _animation;

        public IAnimation Animation => _animation;

        public bool IsPlaying => _cts != null;

        public void SetAnimation(Animation animation)
        {
            _animation = animation;
        }

        public void Play()
        {
            if(IsPlaying)
            {
                Stop();
                Play();
            } 

            try
            {
                _cts = new();
                AnimationTask(_cts.Token).Forget();
            }
            catch (OperationCanceledException)
            {
                
            }
        }

        public async UniTaskVoid AnimationTask(CancellationToken token)
        {
            _animation.SetProgress(default(float));
            var stopwatch = Stopwatch.StartNew();

            while (_animation.CurrentProgress < 1 && token.IsCancellationRequested == false)
            {
                stopwatch.Restart();
                await UniTask.Yield(token).SuppressCancellationThrow();
                _animation.NextStep((float)stopwatch.Elapsed.Ticks / TimeSpan.TicksPerSecond);
            }

            stopwatch.Stop();
            _cts = null;
        }

        public void Stop()
        {
            if (IsPlaying)
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }

        public void SkipToEnd()
        {
            float progressValue = default(float);
            _animation.SetProgress(++progressValue);
        }
    }
}