using Common;
using Engine;

namespace Cards.OneShotEffects
{
    /// <summary>
    /// Salvage is a term for returning a card from your graveyard to your hand.
    /// </summary>
    abstract class SalvageEffect : CardMovingChoiceEffect
    {
        protected SalvageEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.Graveyard, ZoneType.Hand)
        {
        }

        protected SalvageEffect(SalvageEffect effect) : base(effect)
        {
        }
    }
}
