using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ReturnUpToCreaturesFromYourGraveyardToYourHandEffect : SalvageCreatureEffect
    {
        public ReturnUpToCreaturesFromYourGraveyardToYourHandEffect(int maximum) : base(0, maximum)
        {
        }

        public ReturnUpToCreaturesFromYourGraveyardToYourHandEffect(ReturnUpToCreaturesFromYourGraveyardToYourHandEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnUpToCreaturesFromYourGraveyardToYourHandEffect(this);
        }

        public override string ToString()
        {
            return Maximum == 1 ? "You may return a creature from your graveyard to your hand." : $"Return up to {Maximum} creatures from your graveyard to your hand.";
        }
    }
}
