using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect : PowerModifyingMultiplierEffect
    {
        public GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(int power) : base(power, new CardFilters.OpponentsManaZoneTappedCardFilter())
        {
        }

        public GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(this);
        }

        public override string ToString()
        {
            return $"This creature gets +{_power} power for each tapped card in your opponent's mana zone.";
        }
    }
}