using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect : ShieldBurnEffect
    {
        public ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect() : base(new CardFilters.OwnersShieldZoneCardFilter(), 1, 1, true) { }

        public override IOneShotEffect Copy()
        {
            return new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect();
        }

        public override string ToString()
        {
            return "Choose one of your shields and put it into your graveyard.";
        }
    }
}
