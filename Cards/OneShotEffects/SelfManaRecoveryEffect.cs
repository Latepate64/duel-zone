using Common;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class SelfManaRecoveryEffect : ManaRecoveryEffect
    {
        /// <summary>
        /// Mana Recovery is a term given to cards that return cards in your mana zone to your hand.
        /// </summary>
        public SelfManaRecoveryEffect(int minimum, int maximum, bool controllerChooses, CardType cardType) : base(minimum, maximum, controllerChooses, new CardFilters.OwnersManaZoneCardFilter { CardType = cardType })
        {
        }

        public SelfManaRecoveryEffect(SelfManaRecoveryEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new SelfManaRecoveryEffect(this);
        }
    }
}
