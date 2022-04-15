using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM03
{
    class SnipStrikerBullraizer : Creature
    {
        public SnipStrikerBullraizer() : base("Snip Striker Bullraizer", 2, 3000, Engine.Subtype.Dragonoid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new SnipStrikerBullraizerEffect());
        }
    }

    class SnipStrikerBullraizerEffect : ContinuousEffect, ICannotAttackEffect
    {
        public SnipStrikerBullraizerEffect() : base()
        {
        }

        public bool Applies(Engine.ICard creature, IGame game)
        {
            var ability = GetSourceAbility(game);
            return IsSourceOfAbility(creature, game) && game.BattleZone.GetCreatures(ability.GetOpponent(game).Id).Count() > game.BattleZone.GetCreatures(ability.Controller).Count();
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
