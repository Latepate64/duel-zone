using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class SilvermoonTrailblazer : Creature
    {
        public SilvermoonTrailblazer() : base("Silvermoon Trailblazer", 4, 3000, Race.BeastFolk, Civilization.Nature)
        {
            AddTapAbility(new SilvermoonTrailblazerOneShotEffect());
        }
    }

    class SilvermoonTrailblazerOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new SilvermoonTrailblazerContinuousEffect(source.GetController(game).ChooseRace(ToString())));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SilvermoonTrailblazerOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose a race. Creatures of that race can't be blocked by creatures that have power 3000 or less this turn.";
        }
    }

    class SilvermoonTrailblazerContinuousEffect : ContinuousEffects.UntilEndOfTurnEffect, IUnblockableEffect
    {
        private readonly Race _race;

        public SilvermoonTrailblazerContinuousEffect(SilvermoonTrailblazerContinuousEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public SilvermoonTrailblazerContinuousEffect(Race race) : base()
        {
            _race = race;
        }

        public bool Applies(ICard attacker, ICard blocker, IGame game)
        {
            return attacker.HasRace(_race) && blocker.Power <= 3000;
        }

        public override IContinuousEffect Copy()
        {
            return new SilvermoonTrailblazerContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"{_race}s can't be blocked by creatures that have power 3000 or less this turn.";
        }
    }
}
