using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class SilvermoonTrailblazer : Creature
    {
        public SilvermoonTrailblazer() : base("Silvermoon Trailblazer", 4, 3000, Subtype.BeastFolk, Civilization.Nature)
        {
            AddTapAbility(new SilvermoonTrailblazerOneShotEffect());
        }
    }

    class SilvermoonTrailblazerOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new SilvermoonTrailblazerContinuousEffect(source.GetController(game).ChooseRace()));
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

    class SilvermoonTrailblazerContinuousEffect : ContinuousEffect, IUnblockableEffect
    {
        private readonly Subtype _subtype;

        public SilvermoonTrailblazerContinuousEffect(SilvermoonTrailblazerContinuousEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public SilvermoonTrailblazerContinuousEffect(Subtype subtype) : base(new CardFilters.BattleZoneSubtypeCreatureFilter(subtype), new Durations.UntilTheEndOfTheTurn())
        {
            _subtype = subtype;
        }

        public bool Applies(Engine.ICard blocker, IGame game)
        {
            return blocker.Power <= 3000;
        }

        public override IContinuousEffect Copy()
        {
            return new SilvermoonTrailblazerContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"{_subtype}s can't be blocked by creatures that have power 3000 or less this turn.";
        }
    }
}
