using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect : ManaFeedEffect
    {
        public YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect() : base(1, 1, false)
        {
        }

        public YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect(this);
        }

        public override string ToString()
        {
            return "Your opponent chooses one of his creatures in the battle zone and puts it into his mana zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Applier.Opponent);
        }
    }
}
