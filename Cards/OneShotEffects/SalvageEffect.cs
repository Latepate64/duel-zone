using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class SalvageEffect : CardMovingChoiceEffect
    {
        /// <summary>
        /// Salvage is a term for returning a card from your graveyard to your hand.
        /// </summary>
        public SalvageEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.Graveyard, ZoneType.Hand)
        {
        }

        public SalvageEffect(SalvageEffect effect) : base(effect)
        {
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "Return" : "Your opponent returns")} {GetAmountAsText()} {Filter} to its owner's hand.";
        }

        public override OneShotEffect Copy()
        {
            return new SalvageEffect(this);
        }
    }
}
