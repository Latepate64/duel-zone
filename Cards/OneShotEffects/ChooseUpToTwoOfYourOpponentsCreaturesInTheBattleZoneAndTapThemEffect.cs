using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect : TapChoiceEffect
    {
        public ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect() : base(0, 2, true)
        {
        }

        public ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(this);
        }

        public override string ToString()
        {
            return $"Choose up to {Maximum} of your opponent's creatures in the battle zone and tap them.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier);
        }
    }
}
