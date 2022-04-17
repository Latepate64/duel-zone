using Cards.OneShotEffects;

namespace Cards.Cards.DM09
{
    class BlizzardOfSpears : Spell
    {
        public BlizzardOfSpears() : base("Blizzard of Spears", 6, Engine.Civilization.Fire)
        {
            // Destroy all creatures that have power 4000 or less.
            AddSpellAbilities(new DestroyMaxPowerAreaOfEffect(4000));
        }
    }
}
