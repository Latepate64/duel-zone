using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect : TapChoiceEffect
    {
        public YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect() : base(0, 1, true)
        {
        }

        public YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect(YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect(this);
        }

        public override string ToString()
        {
            return "You may choose a darkness or fire creature in the battle zone and tap it.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, Applier).Where(x => x.HasCivilization(Civilization.Darkness, Civilization.Fire));
        }
    }
}