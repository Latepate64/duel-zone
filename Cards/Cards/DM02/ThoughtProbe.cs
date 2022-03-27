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
            AddSpellAbilities(new ThoughtProbeEffect());
        }
    }

    class ThoughtProbeEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Controller);
            if (game.BattleZone.GetCreatures(game.GetOpponent(player).Id).Count() >= 3)
            {
                player.DrawCards(3, game);
            }
            return true;
        }

        public override IOneShotEffect Copy()
        {
            return new ThoughtProbeEffect();
        }

        public override string ToString()
        {
            return "If your opponent has 3 or more creatures in the battle zone, draw 3 cards.";
        }
    }
}
