using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DestroyOneOfYourOpponentsCreaturesEffect : DestroyEffect
    {
        public DestroyOneOfYourOpponentsCreaturesEffect() : base(new CardFilters.OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyOneOfYourOpponentsCreaturesEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures.";
        }
    }
}
