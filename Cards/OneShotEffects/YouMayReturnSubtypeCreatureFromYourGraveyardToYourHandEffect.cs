using Common;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect : SalvageEffect
    {
        private readonly Subtype _subtype;

        public YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(Subtype subtype) : base(new CardFilters.OwnersGraveyardSubtypeCreatureFilter(subtype), 0, 1, true)
        {
            _subtype = subtype;
        }

        public YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public override OneShotEffect Copy()
        {
            return new YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(this);
        }

        public override string ToString()
        {
            return $"You may return a {_subtype} from your graveyard to your hand.";
        }
    }
}
