using System;
using System.Runtime.InteropServices;
using System.Threading;
using WindowsInput;

namespace RecoilController
{
    public class RecoilEngine
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private InputSimulator _input = new InputSimulator();
        private bool _isActive = false;
        private int _vertical = 110;
        private int _horizontal = -5;
        private int _horizontalDelay = 62;
        private int _horizontalDuration = 3398;
        private bool _isShooting = false;
        private DateTime _lmbStartTime;

        private int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public int Vertical
        {
            get => _vertical;
            set => _vertical = Clamp(value, 0, 200);
        }

        public int Horizontal
        {
            get => _horizontal;
            set => _horizontal = Clamp(value, -15, 15);
        }

        public int HorizontalDelay
        {
            get => _horizontalDelay;
            set => _horizontalDelay = Clamp(value, 0, 500);
        }

        public int HorizontalDuration
        {
            get => _horizontalDuration;
            set => _horizontalDuration = Clamp(value, 0, 5000);
        }

        public void Loop()
        {
            while (true)
            {
                if (_isActive && IsLeftMousePressed())
                {
                    if (!_isShooting)
                    {
                        _isShooting = true;
                        _lmbStartTime = DateTime.Now;
                    }

                    int yMove = _vertical;
                    int xMove = 0;

                    double holdMs = (DateTime.Now - _lmbStartTime).TotalMilliseconds;
                    if (holdMs >= _horizontalDelay)
                    {
                        if (_horizontalDuration == 0 || holdMs <= _horizontalDelay + _horizontalDuration)
                        {
                            xMove = _horizontal;
                        }
                    }

                    if (yMove != 0 || xMove != 0)
                    {
                        _input.Mouse.MoveMouseBy(xMove, yMove);
                    }
                }
                else
                {
                    _isShooting = false;
                }
                Thread.Sleep(5);
            }
        }

        private bool IsLeftMousePressed()
        {
            return (GetAsyncKeyState(0x01) & 0x8000) != 0;
        }
    }
}