using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YouMayReturnSpellFromYourGraveyardToYourHandEffect : SalvageEffect
    {
        public YouMayReturnSpellFromYourGraveyardToYourHandEffect() : base(new CardFilters.OwnersGraveyardSpellFilter(), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayReturnSpellFromYourGraveyardToYourHandEffect();
        }

        public override string ToString()
        {
            return "You may return a spell from your graveyard to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).Graveyard.Spells;
        }
    }
}
