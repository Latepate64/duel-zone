using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM02
{
    class ThoughtProbe : Spell
    {
        public ThoughtProbe() : base("Thought Probe", 4, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ThoughtProbeEffect());
        }
    }

    class ThoughtProbeEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            if (game.BattleZone.GetCreatures(source.GetOpponent(game).Id).Count() >= 3)
            {
                source.GetController(game).DrawCards(3, game, source);
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
