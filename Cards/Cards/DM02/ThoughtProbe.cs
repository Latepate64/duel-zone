using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class ThoughtProbe : Engine.Spell
    {
        public ThoughtProbe() : base("Thought Probe", 4, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ThoughtProbeEffect());
        }
    }

    class ThoughtProbeEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            if (game.BattleZone.GetCreatureCount(GetOpponent(game).Id) >= 3)
            {
                Controller.DrawCards(3, game, Ability);
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
