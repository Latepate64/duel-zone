using Engine;
using Engine.Zones;

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
    }
}
