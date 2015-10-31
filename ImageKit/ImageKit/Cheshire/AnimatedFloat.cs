namespace ImageKit.Cheshire
{
    class AnimatedFloat
    {
        private enum InterpolationMode
        {
            None,
            Lerp
        }

        public AnimatedFloat(float v)
        {
            _currentValue = v;
        }

        private InterpolationMode _currentMode = InterpolationMode.None;

        private float _originValue;
        private float _targetValue;
        private int _originTick;
        private int _targetTick;
        private float _duration;

        private float _currentValue;

        public float Value
        {
            get
            {
                Update();
                return _currentValue;
            }
        }

        public void Update()
        {
            if (_currentMode == InterpolationMode.None)
            {
                return;
            }
            // lerp
            var currentTick = Animator.Instance.Tick;
            if (currentTick >= _targetTick)
            {
                _currentValue = _targetValue;
                _currentMode = InterpolationMode.None;
                return;
            }
            var amount = (currentTick - _originTick)/_duration;
            _currentValue = _originValue + (_targetValue - _originValue) * amount;
        }

        public void Animate(float destinationValue, int intervalTime)
        {
            _originValue = _currentValue;
            _targetValue = destinationValue;

            _duration = intervalTime; // keep in float to speed calc

            _originTick = Animator.Instance.Tick;
            _targetTick = _originTick + intervalTime;

            _currentMode = InterpolationMode.Lerp;
        }

        public static implicit operator AnimatedFloat(float d)
        {
            return new AnimatedFloat(d);
        }

        public static implicit operator float(AnimatedFloat d)
        {
            return d.Value;
        }
    }
}
