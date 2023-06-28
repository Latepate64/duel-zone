using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect : TapChoiceEffect
    {
        public ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect(ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect effect) : base(effect)
        {
        }

        public ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone and tap it.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, Applier.Opponent.Id);
        }
    }
}
