using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayDestroyOneOfYourOpponentsCreaturesEffect : DestroyEffect
    {
        public YouMayDestroyOneOfYourOpponentsCreaturesEffect() : base(new CardFilters.OpponentsBattleZoneChoosableCreatureFilter(), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDestroyOneOfYourOpponentsCreaturesEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your opponent's creatures.";
        }
    }
}
