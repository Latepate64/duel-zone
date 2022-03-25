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

        public override OneShotEffect Copy()
        {
            return new DiamondCutterOneShotEffect();
        }

        public override string ToString()
        {
            return "This turn, ignore any effects that would prevent your creatures from attacking your opponent.";
        }
    }

    class DiamondCutterContinuousEffect : IgnoreCannotAttackPlayersEffects
    {
        public DiamondCutterContinuousEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), new Engine.Durations.UntilTheEndOfTheTurn())
        {
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
