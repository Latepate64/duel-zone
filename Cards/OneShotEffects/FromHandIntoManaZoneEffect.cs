using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class FromHandIntoManaZoneEffect : CardMovingChoiceEffect
    {
        public FromHandIntoManaZoneEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public FromHandIntoManaZoneEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.Hand, ZoneType.ManaZone)
        {
        }

        public override OneShotEffect Copy()
        {
            return new FromHandIntoManaZoneEffect(this);
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "Put" : "Your opponent puts")} {GetAmountAsText()} {Filter} into their owner's mana zone.";
        }
    }
}
