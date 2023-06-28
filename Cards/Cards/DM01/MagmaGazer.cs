using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM01
{
    class MagmaGazer : Spell
    {
        public MagmaGazer() : base("Magma Gazer", 3, Civilization.Fire)
        {
            AddSpellAbilities(new MagmaGazerEffect());
        }
    }

    class MagmaGazerEffect : CardSelectionEffect
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

        protected override void Apply(IAbility source, params ICard[] cards)
        {
            Game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.BattleZone.GetCreatures(Applier);
        }
    }
}