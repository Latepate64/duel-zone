using Common;

namespace Cards.OneShotEffects
{
    abstract class DestroyEffect : CardMovingChoiceEffect
    {
        protected DestroyEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Graveyard)
        {
        }

        protected DestroyEffect(DestroyEffect effect) : base(effect)
        {
        }
    }
}
