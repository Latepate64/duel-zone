using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class MigasaAdeptOfChaos : Creature
    {
        public MigasaAdeptOfChaos() : base("Migasa, Adept of Chaos", 3, 2000, Subtype.Human, Civilization.Fire)
        {
            AddAbilities(new TapAbility(new MigasaAdeptOfChaosEffect()));
        }
    }

    class MigasaAdeptOfChaosEffect : OneShotEffects.GrantChoiceEffect
    {
        public MigasaAdeptOfChaosEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Fire), 1, 1, true)
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
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(new CardFilters.TargetsFilter(cards), new StaticAbilities.DoubleBreakerAbility()));
        }
    }
}
