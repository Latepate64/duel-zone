using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM03
{
    class SnipStrikerBullraizer : Creature
    {
        public SnipStrikerBullraizer() : base("Snip Striker Bullraizer", 2, 3000, Subtype.Dragonoid, Civilization.Fire)
        {
            AddStaticAbilities(new SnipStrikerBullraizerEffect());
        }
    }

    class SnipStrikerBullraizerEffect : ContinuousEffect, ICannotAttackEffect
    {
        public SnipStrikerBullraizerEffect() : base(new TargetFilter())
        {
        }

        public bool Applies(IGame game)
        {
            var ability = game.GetAbility(SourceAbility);
            return game.BattleZone.GetCreatures(ability.GetOpponent(game).Id).Count() > game.BattleZone.GetCreatures(ability.Controller).Count();
        }

        public override IContinuousEffect Copy()
        {
            return new SnipStrikerBullraizerEffect();
        }

        public override string ToString()
        {
            return "This creature can't attack while your opponent has more creatures in the battle zone than you do.";
        }
    }
}
