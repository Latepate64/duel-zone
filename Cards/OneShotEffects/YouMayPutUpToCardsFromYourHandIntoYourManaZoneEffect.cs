using Common;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect : CardMovingChoiceEffect
    {
        private readonly int _maximum;

        public YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(int maximum) : base(new CardFilters.OwnersHandCardFilter(), 0, maximum, true, ZoneType.Hand, ZoneType.ManaZone)
        {
            _maximum = maximum;
        }

        public YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect effect) : base(effect)
        {
            _maximum = effect._maximum;
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(this);
        }

        public override string ToString()
        {
            return $"{(_maximum == 1 ? "You may put a card" : $"Put up to {_maximum}")} from your hand into your mana zone.";
        }
    }
}
