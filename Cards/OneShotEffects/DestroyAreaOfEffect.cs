using Common;

namespace Cards.OneShotEffects
{
    abstract class DestroyAreaOfEffect : CardMovingAreaOfEffect
    {
        protected DestroyAreaOfEffect(DestroyAreaOfEffect effect) : base(effect)
        {
        }

        protected DestroyAreaOfEffect() : base(ZoneType.BattleZone, ZoneType.Graveyard)
        {
        }
    }
}
