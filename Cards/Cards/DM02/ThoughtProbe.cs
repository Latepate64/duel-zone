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
        public override void Apply()
        {
            if (Game.BattleZone.GetCreatures(Applier.Opponent).Count() >= 3)
            {
                Applier.DrawCards(3, Ability);
            }
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
