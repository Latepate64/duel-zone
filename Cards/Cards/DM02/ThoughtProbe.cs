using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM02
{
    class ThoughtProbe : Spell
    {
        public ThoughtProbe() : base("Thought Probe", 4, Common.Civilization.Water)
        {
            ShieldTrigger = true;

            // When you cast this spell, if your opponent has 3 or more creatures in the battle zone, draw 3 cards.
            AddAbilities(new SpellAbility(new ThoughtProbeEffect()));
        }
    }

    class ThoughtProbeEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            var player = game.GetPlayer(source.Owner);
            if (game.BattleZone.GetCreatures(game.GetOpponent(player).Id).Count() >= 3)
            {
                player.DrawCards(3, game);
            }
        }

        public override OneShotEffect Copy()
        {
            return new ThoughtProbeEffect();
        }

        public override string ToString()
        {
            return "If your opponent has 3 or more creatures in the battle zone, draw 3 cards.";
        }
    }
}
