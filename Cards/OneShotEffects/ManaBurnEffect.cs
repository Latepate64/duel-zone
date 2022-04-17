using Engine;

namespace Cards.OneShotEffects
{
    abstract class ManaBurnEffect : CardMovingChoiceEffect
    {
        protected ManaBurnEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Graveyard)
        {
        }

        protected ManaBurnEffect(ManaBurnEffect effect) : base(effect)
        {
        }
    }
}
