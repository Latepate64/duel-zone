using Common;
using Engine;

namespace Cards.OneShotEffects
{
    abstract class DestroyAreaOfEffect : CardMovingAreaOfEffect
    {
        protected DestroyAreaOfEffect(DestroyAreaOfEffect effect) : base(effect)
        {
        }

        protected DestroyAreaOfEffect(ICardFilter filter) : base(ZoneType.BattleZone, ZoneType.Graveyard, filter)
        {
        }
    }
}
