using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM07
{
    class KingBenthos : Creature
    {
        public KingBenthos() : base("King Benthos", 8, 6000, Race.Leviathan, Civilization.Water)
        {
            AddDoubleBreakerAbility();
            AddTapAbility(new KingBenthosEffect());
        }
    }

    class KingBenthosEffect : OneShotEffect
    {
        public KingBenthosEffect() : base()
        {
        }

        public override void Apply(IGame game, IAbility source)
        {
            var creatures = game.BattleZone.GetCreatures(source.Controller, Civilization.Water);
            game.AddContinuousEffects(source, new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
                new StaticAbility(new ThisCreatureCannotBeBlockedEffect()),
                creatures.ToArray()));
        }

        public override IOneShotEffect Copy()
        {
            return new KingBenthosEffect();
        }

        public override string ToString()
        {
            return "Each of your water creatures gets \"This creature can't be blocked\" until the end of the turn.";
        }
    }
}
