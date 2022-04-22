using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    abstract class ReturnUpToCreaturesFromYourGraveyardToYourHandEffect : SalvageCreatureEffect
    {
        protected ReturnUpToCreaturesFromYourGraveyardToYourHandEffect(int maximum) : base(0, maximum)
        {
        }

        protected ReturnUpToCreaturesFromYourGraveyardToYourHandEffect(ReturnUpToCreaturesFromYourGraveyardToYourHandEffect effect) : base(effect)
        {
        }

        public override string ToString()
        {
            return Maximum == 1 ? "You may return a creature from your graveyard to your hand." : $"Return up to {Maximum} creatures from your graveyard to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.Graveyard.Creatures;
        }
    }

    class YouMayReturnCreatureFromYourGraveyardToYourHandEffect : ReturnUpToCreaturesFromYourGraveyardToYourHandEffect
    {
        public YouMayReturnCreatureFromYourGraveyardToYourHandEffect() : base(1)
        {
        }

        public YouMayReturnCreatureFromYourGraveyardToYourHandEffect(ReturnUpToCreaturesFromYourGraveyardToYourHandEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayReturnCreatureFromYourGraveyardToYourHandEffect(this);
        }
    }

    class ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect : ReturnUpToCreaturesFromYourGraveyardToYourHandEffect
    {
        public ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect() : base(2)
        {
        }

        public ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect(ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect(this);
        }
    }
}
