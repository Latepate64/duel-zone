using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YouMayReturnSpellFromYourGraveyardToYourHandEffect : SalvageEffect
    {
        public YouMayReturnSpellFromYourGraveyardToYourHandEffect() : base(0, 1, true)
        {
        }

        public YouMayReturnSpellFromYourGraveyardToYourHandEffect(SalvageEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayReturnSpellFromYourGraveyardToYourHandEffect(this);
        }

        public override string ToString()
        {
            return "You may return a spell from your graveyard to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return GetController(game).Graveyard.Spells;
        }
    }
}
