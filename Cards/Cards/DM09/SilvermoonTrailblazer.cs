﻿using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class SilvermoonTrailblazer : Creature
    {
        public SilvermoonTrailblazer() : base("Silvermoon Trailblazer", 4, 3000, Engine.Subtype.BeastFolk, Engine.Civilization.Nature)
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
        private readonly Subtype _subtype;

        public SilvermoonTrailblazerContinuousEffect(SilvermoonTrailblazerContinuousEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public SilvermoonTrailblazerContinuousEffect(Subtype subtype) : base()
        {
            _subtype = subtype;
        }

        public bool Applies(ICard attacker, ICard blocker, IGame game)
        {
            return attacker.HasSubtype(_subtype) && blocker.Power <= 3000;
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
