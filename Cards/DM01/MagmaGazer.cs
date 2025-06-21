using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM01
{
    class MagmaGazer : Spell
    {
        public MagmaGazer() : base("Magma Gazer", 3, Civilization.Fire)
        {
            AddSpellAbilities(new MagmaGazerEffect());
        }
    }

    class MagmaGazerEffect : CreatureSelectionEffect
    {
        public MagmaGazerEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MagmaGazerEffect();
        }

        public override string ToString()
        {
            return "One of your creatures gets \"power attacker +4000\" and \"double breaker\" until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params Creature[] cards)
        {
            game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(cards));
        }

        protected override IEnumerable<Creature> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Ability.Controller.Id);
        }
    }
}