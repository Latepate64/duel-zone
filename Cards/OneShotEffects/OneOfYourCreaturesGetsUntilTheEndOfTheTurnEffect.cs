using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class OneOfYourCreaturesGetsUntilTheEndOfTheTurnEffect : CardSelectionEffect
    {
        public int Power { get; }

        public OneOfYourCreaturesGetsUntilTheEndOfTheTurnEffect(OneOfYourCreaturesGetsUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public OneOfYourCreaturesGetsUntilTheEndOfTheTurnEffect(int power) : base(new OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
            Power = power;
        }

        public override IOneShotEffect Copy()
        {
            return new OneOfYourCreaturesGetsUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return $"One of your creatures gets +{Power} power until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(Power, cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }
}
