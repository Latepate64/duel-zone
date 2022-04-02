using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayLookAtOneOfYourOpponentsShieldsEffect : LookEffect
    {
        public YouMayLookAtOneOfYourOpponentsShieldsEffect() : base(new CardFilters.OpponentsShieldZoneCardFilter(), 0, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayLookAtOneOfYourOpponentsShieldsEffect();
        }

        public override string ToString()
        {
            return "You may look at one of your opponent's shields. Then put it back where it was.";
        }
    }

    class LookAtOneOfYourOpponentsShieldsEffect : LookEffect
    {
        public LookAtOneOfYourOpponentsShieldsEffect() : base(new CardFilters.OpponentsShieldZoneCardFilter(), 1, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new LookAtOneOfYourOpponentsShieldsEffect();
        }

        public override string ToString()
        {
            return "Look at one of your opponent's shields.";
        }
    }
}
