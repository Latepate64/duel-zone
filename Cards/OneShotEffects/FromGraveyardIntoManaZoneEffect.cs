using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class FromGraveyardIntoManaZoneEffect : CardMovingChoiceEffect
    {
        public FromGraveyardIntoManaZoneEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public FromGraveyardIntoManaZoneEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.Graveyard, ZoneType.ManaZone)
        {
        }

        public override OneShotEffect Copy()
        {
            return new FromGraveyardIntoManaZoneEffect(this);
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "put" : "your opponent puts")} {GetAmountAsText()} {Filter} into their owner's mana zone.";
        }
    }
}
