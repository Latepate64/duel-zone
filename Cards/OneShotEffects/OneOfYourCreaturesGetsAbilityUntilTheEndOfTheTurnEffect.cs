using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    abstract class OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect : CardSelectionEffect
    {
        private readonly IAbility _ability;

        public OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(IAbility ability) : base(1, 1, true)
        {
            _ability = ability;
        }

        public OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _ability = effect._ability;
        }

        public override string ToString()
        {
            return $"One of your creatures in the battle zone gets \"{_ability.ToString().ToLower()}\" until the end of the turn.";
        }

        protected override void Apply(IAbility source, params ICard[] cards)
        {
            Game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(_ability, cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.BattleZone.GetCreatures(Applier);
        }
    }

    class OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect : OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect
    {
        public OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect() : base(new StaticAbilities.SpeedAttackerAbility())
        {
        }

        public OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect(OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect(this);
        }
    }

    class OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect : OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect
    {
        public OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect() : base(new StaticAbilities.SlayerAbility())
        {
        }

        public OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect(OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect(this);
        }
    }
}
