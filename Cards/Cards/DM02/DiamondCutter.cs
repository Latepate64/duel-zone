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
            AddAbilities(new SpellAbility(new DiamondCutterEffect()));
        }
    }

    class DiamondCutterEffect : OneShotEffect
    {
        public override object Apply(Game game, Ability source)
        {
            game.AddContinuousEffects(source, new IgnoreCannotAttackPlayersEffects(new CardFilters.OwnersBattleZoneCreatureFilter(), new Engine.Durations.UntilTheEndOfTheTurn()));
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new DiamondCutterEffect();
        }

        public override string ToString()
        {
            return "This turn, ignore any effects that would prevent your creatures from attacking your opponent.";
        }
    }
}
