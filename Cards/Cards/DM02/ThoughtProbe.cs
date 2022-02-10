using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class ThoughtProbe : Spell
    {
        public ThoughtProbe() : base("Thought Probe", 4, Common.Civilization.Water)
        {
            ShieldTrigger = true;

            // When you cast this spell, if your opponent has 3 or more creatures in the battle zone, draw 3 cards.
            Abilities.Add(new SpellAbility(new OneShotEffects.ThoughtProbeEffect()));
        }
    }
}
