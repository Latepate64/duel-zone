using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ReturnSpellFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public ReturnSpellFromYourManaZoneToYourHandEffect() : base(1, 1, true, new CardFilters.OwnersManaZoneSpellFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnSpellFromYourManaZoneToYourHandEffect();
        }

        public override string ToString()
        {
            return "Return a spell from your mana zone to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).ManaZone.Spells;
        }
    }
}
