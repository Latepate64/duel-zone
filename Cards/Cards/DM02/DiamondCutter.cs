using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;

namespace Cards.Cards.DM02
{
    class DiamondCutter : Spell
    {
        public DiamondCutter() : base("Diamond Cutter", 5, Engine.Civilization.Light)
        {
            AddSpellAbilities(new DiamondCutterOneShotEffect());
        }
    }

    class DiamondCutterOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new DiamondCutterContinuousEffect(source.Controller));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new DiamondCutterOneShotEffect();
        }

        public override string ToString()
        {
            return "This turn, ignore any effects that would prevent your creatures from attacking your opponent.";
        }
    }

    class DiamondCutterContinuousEffect : UntilEndOfTurnEffect, IIgnoreCannotAttackPlayersEffects
    {
        private readonly Guid _controller;

        public DiamondCutterContinuousEffect(System.Guid controller) : base()
        {
            _controller = controller;
        }

        public DiamondCutterContinuousEffect(DiamondCutterContinuousEffect effect) : base(effect)
        {
            _controller = effect._controller;
        }

        public bool Applies(Engine.ICard attacker, IGame game)
        {
            return attacker.Owner == _controller;
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
