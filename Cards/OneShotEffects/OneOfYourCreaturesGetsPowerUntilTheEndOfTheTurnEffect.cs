using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect : CardSelectionEffect, IPowerable
    {
        public int Power { get; }

        public OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(int power) : base(1, 1, true)
        {
            Power = power;
        }

        public override IOneShotEffect Copy()
        {
            return new OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return $"One of your creatures gets +{Power} power until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(Power, cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Ability.ControllerPlayer.Id);
        }
    }
}
