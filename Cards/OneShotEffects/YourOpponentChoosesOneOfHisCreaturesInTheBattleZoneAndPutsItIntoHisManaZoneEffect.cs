using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect : ManaFeedEffect
    {
        public YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect() : base(new CardFilters.OpponentsBattleZoneCreatureFilter(), 1, 1, false)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect();
        }

        public override string ToString()
        {
            return "Your opponent chooses one of his creatures in the battle zone and puts it into his mana zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.GetOpponent(game).Id);
        }
    }
}
