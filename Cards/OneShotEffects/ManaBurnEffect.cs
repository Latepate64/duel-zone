using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ManaBurnEffect : CardMovingChoiceEffect
    {
        public ManaBurnEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Graveyard)
        {
        }

        public ManaBurnEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "Put" : "Your opponent puts")} {GetAmountAsText()} {Filter} into their owner's graveyard.";
        }

        public override OneShotEffect Copy()
        {
            return new ManaBurnEffect(this);
        }
    }
}
