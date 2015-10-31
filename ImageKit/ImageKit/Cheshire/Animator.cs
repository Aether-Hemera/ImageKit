using System.Diagnostics;

namespace ImageKit.Cheshire
{
    public sealed class Animator
    {
        private bool _autoTick = true;
        private Stopwatch _sw;

        private int _tick;

        public int Tick
        {
            get
            {
                if (!_autoTick) 
                    return _tick;
                if (_sw == null)
                    _sw = Stopwatch.StartNew();
                return (int)_sw.ElapsedMilliseconds;
            }
            set { _tick = value; }
        }

        Animator()
        {
        }

        public static Animator Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            // ReSharper disable once InconsistentNaming
            internal static readonly Animator instance = new Animator();
        }
    }
}
