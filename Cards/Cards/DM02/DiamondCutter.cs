using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;

namespace Cards.Cards.DM02
{
    class DiamondCutter : Spell
    {
        public DiamondCutter() : base("Diamond Cutter", 5, Civilization.Light)
        {
            AddSpellAbilities(new DiamondCutterOneShotEffect());
        }
    }

    class DiamondCutterOneShotEffect : OneShotEffect
    {
        public DiamondCutterOneShotEffect()
        {
        }

        public DiamondCutterOneShotEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new DiamondCutterContinuousEffect(Ability.Controller.Id));
        }

        public override IOneShotEffect Copy()
        {
            return new DiamondCutterOneShotEffect(this);
        }

        public override string ToString()
        {
            return "This turn, ignore any effects that would prevent your creatures from attacking your opponent.";
        }
    }

    class DiamondCutterContinuousEffect : UntilEndOfTurnEffect, IIgnoreCannotAttackPlayersEffects
    {
        private readonly Guid _controller;

        public DiamondCutterContinuousEffect(Guid controller) : base()
        {
            _controller = controller;
        }

        public DiamondCutterContinuousEffect(DiamondCutterContinuousEffect effect) : base(effect)
        {
            _controller = effect._controller;
        }

        public bool IgnoreCannotAttackPlayersEffects(ICard attacker, IGame game)
        {
            return attacker.Owner.Id == _controller;
        }

        public override IContinuousEffect Copy()
        {
            return new DiamondCutterContinuousEffect(this);
        }

        public override string ToString()
        {
            return "This turn, ignore any effects that would prevent your creatures from attacking your opponent.";
        }
    }
}
