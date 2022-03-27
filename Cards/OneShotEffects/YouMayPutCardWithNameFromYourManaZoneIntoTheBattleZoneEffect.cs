using Common;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect : CardMovingChoiceEffect
    {
        private readonly string _name;

        public YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect effect) : base(effect)
        {
            _name = effect._name;
        }

        public YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(string name) : base(new CardFilters.OwnersManaZoneNamedCardFilter(name), 0, 1, true, ZoneType.ManaZone, ZoneType.BattleZone)
        {
            _name = name;
        }

        public override OneShotEffect Copy()
        {
            return new YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(this);
        }

        public override string ToString()
        {
            return $"You may choose an {_name} in your mana zone and put it into the battle zone.";
        }
    }
}
