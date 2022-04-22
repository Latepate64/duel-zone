using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    abstract class YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect : CardMovingChoiceEffect
    {
        private readonly int _maximum;

        protected YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(int maximum) : base(0, maximum, true, ZoneType.Hand, ZoneType.ManaZone)
        {
            _maximum = maximum;
        }

        protected YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect effect) : base(effect)
        {
            _maximum = effect._maximum;
        }

        public override string ToString()
        {
            return $"{(_maximum == 1 ? "You may put a card" : $"Put up to {_maximum}")} from your hand into your mana zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.Hand.Cards;
        }
    }
}
