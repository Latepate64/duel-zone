using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect : CardMovingChoiceEffect
    {
        private readonly string _name;

        protected YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect effect) : base(effect)
        {
            _name = effect._name;
        }

        protected YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(string name) : base(0, 1, true, ZoneType.ManaZone, ZoneType.BattleZone)
        {
            _name = name;
        }

        public override string ToString()
        {
            return $"You may choose an {_name} in your mana zone and put it into the battle zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Applier.ManaZone.Cards.Where(x => x.Name == _name);
        }
    }
}
