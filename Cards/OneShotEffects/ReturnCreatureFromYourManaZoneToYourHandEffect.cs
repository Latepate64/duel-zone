using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ReturnCreatureFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public ReturnCreatureFromYourManaZoneToYourHandEffect() : base(1, 1, true, new CardFilters.OwnersManaZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnCreatureFromYourManaZoneToYourHandEffect();
        }

        public override string ToString()
        {
            return "Return a creature from your mana zone to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).ManaZone.Creatures;
        }
    }
}
