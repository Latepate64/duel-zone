using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect : CreateContinuousEffectChoiceEffect
    {
        public ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true, new ThisCreatureCannotBeBlockedThisTurnEffect())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect();
        }

        public override string ToString()
        {
            return "Choose one of your creatures in the battle zone. It can't be blocked this turn.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }
}
