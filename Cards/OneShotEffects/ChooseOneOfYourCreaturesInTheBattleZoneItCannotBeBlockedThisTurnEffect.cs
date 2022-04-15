using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect : CardSelectionEffect
    {
        public ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect() : base(1, 1, true)
        {
        }

        public ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect(ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your creatures in the battle zone. It can't be blocked this turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(source, new ChosenCreaturesCannotBeBlockedThisTurnEffect(cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }
}
