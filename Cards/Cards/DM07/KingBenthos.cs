using Cards.ContinuousEffects;
using Effects.Continuous;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class KingBenthos : Creature
    {
        public KingBenthos() : base("King Benthos", 8, 6000, Race.Leviathan, Civilization.Water)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddAbilities(new TapAbility(new KingBenthosEffect()));
        }
    }

    class KingBenthosEffect : OneShotEffect
    {
        public KingBenthosEffect() : base()
        {
        }

        public KingBenthosEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id, Civilization.Water);
            game.AddContinuousEffects(Ability, new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
                new StaticAbility(new ThisCreatureCannotBeBlockedEffect()),
                [.. creatures]));
        }

        public override IOneShotEffect Copy()
        {
            return new KingBenthosEffect(this);
        }

        public override string ToString()
        {
            return "Each of your water creatures gets \"This creature can't be blocked\" until the end of the turn.";
        }
    }
}
