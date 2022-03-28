using Cards.ContinuousEffects;
using Common;
using Engine;
using System;
using System.Linq;

namespace Cards.Cards.DM03
{
    class SnipStrikerBullraizer : Creature
    {
        public SnipStrikerBullraizer() : base("Snip Striker Bullraizer", 2, 3000, Subtype.Dragonoid, Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackEffect(new SnipStrikerBullraizerCondition()));
        }
    }

    class SnipStrikerBullraizerCondition : Condition
    {
        public SnipStrikerBullraizerCondition() : base(new TargetFilter()) { }

        public SnipStrikerBullraizerCondition(SnipStrikerBullraizerCondition condition) : base(condition) { }

        public override bool Applies(IGame game, Guid player)
        {
            return game.BattleZone.GetCreatures(game.GetOpponent(player)).Count() > game.BattleZone.GetCreatures(player).Count();
        }

        public override Condition Copy()
        {
            return new SnipStrikerBullraizerCondition(this);
        }

        public override string ToString()
        {
            return "your opponent has more creatures in the battle zone than you do";
        }
    }
}
