using System;

namespace Content.Server._RMK.GameTime
{
    public sealed class GameTimeManager
    {
        private TimeSpan _gameTime;
        private readonly double _timeAcceleration;

        public TimeSpan GameTime => _gameTime;

        public GameTimeManager(int hour, int minute, double acceleration)
        {
            _gameTime = new TimeSpan(hour, minute, 0);
            _timeAcceleration = acceleration;
        }

        public void Update(double realDeltaSeconds)
        {
            var advance = TimeSpan.FromSeconds(realDeltaSeconds * _timeAcceleration);
            _gameTime = _gameTime.Add(advance);
            if (_gameTime.TotalHours >= 24)
                _gameTime = _gameTime.Subtract(TimeSpan.FromHours(24));
        }

        public string GetFormattedTime() => _gameTime.ToString(@"hh\:mm");
    }
}
