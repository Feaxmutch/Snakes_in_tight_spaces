using Other;

namespace ViewModel
{
    public class Animator
    {
        private readonly IUnityUpdate _unityUpdate;

        private Animation _animation;
        private bool _isPlaying = false;

        public Animator(IUnityUpdate unityUpdate)
        {
            _unityUpdate = unityUpdate;
            _unityUpdate.Updated += OnFrameUpdated;
        }

        public IAnimation Animation => _animation;

        public void SetAnimation(Animation animation)
        {
            _animation = animation;
        }

        public void Play()
        {
            float progressValue = default(float);
            _animation.SetProgress(progressValue);
            _isPlaying = true;
        }

        public void Stop()
        {
            _isPlaying = false;
        }

        public void SkipToEnd()
        {
            float progressValue = default(float);
            _animation.SetProgress(++progressValue);
        }

        private void OnFrameUpdated(float deltaTime)
        {
            if (_isPlaying)
            {
                _animation.NextStep(deltaTime);
            }
        }
    }
}