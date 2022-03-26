using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect : DestroyEffect
    {
        public DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect() : base(new CardFilters.OpponentsBattleZoneChoosableBlockerCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has \"blocker.\"";
        }
    }
}
