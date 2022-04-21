using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect : CardMovingChoiceEffect
    {
        private readonly string _name;

        public YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect effect) : base(effect)
        {
            _name = effect._name;
        }

        public YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(string name) : base(0, 1, true, ZoneType.ManaZone, ZoneType.BattleZone)
        {
            _name = name;
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(this);
        }

        public override string ToString()
        {
            return $"You may choose an {_name} in your mana zone and put it into the battle zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.ManaZone.Cards.Where(x => x.Name == _name);
        }
    }
}
