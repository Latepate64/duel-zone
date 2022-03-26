using Common;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayPutCardFromYourHandIntoYourManaZoneEffect : CardMovingChoiceEffect
    {
        public YouMayPutCardFromYourHandIntoYourManaZoneEffect() : base(new CardFilters.OwnersHandCardFilter(), 0, 1, true, ZoneType.Hand, ZoneType.ManaZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayPutCardFromYourHandIntoYourManaZoneEffect();
        }

        public override string ToString()
        {
            return "You may put a card from your hand into your mana zone.";
        }
    }
}
