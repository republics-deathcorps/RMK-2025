using Robust.Shared.GameObjects;
using Robust.Shared.Map;
using System;
using Content.Shared._RMK.MapTime;
using Robust.Shared.Player;
using Content.Server.Maps;


namespace Content.Server._RMK.GameTime
{
    /// <summary>
    /// Управляет временем на всех картах — инициирует таймер при создании и обновляет каждый апдейт.
    /// </summary>
    public sealed class MapTimeSystem : EntitySystem
    {
        [Dependency] private readonly IMapManager _mapMan = default!;
        public override void Initialize()
        {
            base.Initialize();
            SubscribeLocalEvent<MapTimeComponent, MapInitEvent>(OnMapInit);
        }

        private void OnMapInit(EntityUid uid, MapTimeComponent comp, MapInitEvent ev)
        {
                comp.TimeManager = new GameTimeManager(comp.StartHour, comp.StartMinute, comp.TimeAcceleration);
        }

        public override void Update(float frameTime)
        {
            foreach (var comp in EntityQuery<MapTimeComponent>())
            {
                if (comp.TimeManager == null)
                    continue;
                comp.TimeManager.Update(frameTime);
            }
            }
        }
    }
}
