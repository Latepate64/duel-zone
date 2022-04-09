using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM06
{
    class MigasaAdeptOfChaos : Creature
    {
        public MigasaAdeptOfChaos() : base("Migasa, Adept of Chaos", 3, 2000, Subtype.Human, Civilization.Fire)
        {
            AddTapAbility(new MigasaAdeptOfChaosEffect());
        }
    }

    class MigasaAdeptOfChaosEffect : OneShotEffects.CardSelectionEffect
    {
        public MigasaAdeptOfChaosEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MigasaAdeptOfChaosEffect();
        }

        public override string ToString()
        {
            return "One of your fire creatures in the battle zone gets \"double breaker\" until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(new StaticAbilities.DoubleBreakerAbility(), cards));
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller, Common.Civilization.Fire);
        }
    }
}
