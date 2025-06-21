using OneShotEffects;

namespace Cards.DM09
{
    class BlizzardOfSpears : Engine.Spell
    {
        public BlizzardOfSpears() : base("Blizzard of Spears", 6, Interfaces.Civilization.Fire)
        {
            // Destroy all creatures that have power 4000 or less.
            AddSpellAbilities(new DestroyMaxPowerAreaOfEffect(4000));
        }
    }
}
