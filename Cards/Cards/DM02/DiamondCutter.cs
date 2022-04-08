using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

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
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new DiamondCutterContinuousEffect());
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

    class DiamondCutterContinuousEffect : ContinuousEffects.UntilEndOfTurnEffect, IIgnoreCannotAttackPlayersEffects
    {
        public DiamondCutterContinuousEffect() : base()
        {
        }

        public bool Applies(Engine.ICard attacker, IGame game)
        {
            return attacker.Owner == Controller;
        }

        public override IContinuousEffect Copy()
        {
            return new DiamondCutterContinuousEffect();
        }

        public override string ToString()
        {
            return "This turn, ignore any effects that would prevent your creatures from attacking your opponent.";
        }
    }
}
