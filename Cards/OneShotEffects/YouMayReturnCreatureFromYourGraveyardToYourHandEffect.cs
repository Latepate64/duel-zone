using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayReturnCreatureFromYourGraveyardToYourHandEffect : SalvageCreatureEffect
    {
        public YouMayReturnCreatureFromYourGraveyardToYourHandEffect() : base(0, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayReturnCreatureFromYourGraveyardToYourHandEffect();
        }

        public override string ToString()
        {
            return "You may return a creature from your graveyard to your hand.";
        }
    }
}
