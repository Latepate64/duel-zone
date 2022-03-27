using Common;
using Engine;

namespace Cards.OneShotEffects
{
    abstract class ManaBurnEffect : CardMovingChoiceEffect
    {
        protected ManaBurnEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Graveyard)
        {
        }

        protected ManaBurnEffect(ManaBurnEffect effect) : base(effect)
        {
        }
    }
}
