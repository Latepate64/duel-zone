using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect : ShieldBurnEffect
    {
        public ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect() : base(new CardFilters.OpponentsShieldZoneCardFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's shields and put it into his graveyard.";
        }
    }
}
