using Robust.Shared.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.Serialization.Manager.Attributes;
using System;

namespace Content.Server._RMK.GameTime
{
    /// <summary>
    /// Хранит и отслеживает внутриигровое время для конкретной карты.
    /// </summary>
    [RegisterComponent]
    public sealed partial class MapTimeComponent : Component
    {
        [DataField("startHour")]
        public int StartHour { get; private set; } = 23;

        [DataField("startMinute")]
        public int StartMinute { get; private set; } = 0;

        [DataField("timeAcceleration")]
        public double TimeAcceleration { get; private set; } = 60;

        [ViewVariables]
        public TimeSpan? CurrentTime => TimeManager?.GameTime;

        public GameTimeManager? TimeManager { get; set; }

        public string GetFormattedTime() => TimeManager?.GetFormattedTime() ?? "--:--";
    }
}
