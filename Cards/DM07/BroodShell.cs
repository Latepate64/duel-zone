using Engine.Abilities;

namespace Cards.DM07
{
    sealed class BroodShell : Engine.Creature
    {
        public BroodShell() : base("Brood Shell", 4, 3000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ReturnCreatureFromYourManaZoneToYourHandEffect()));
        }
    }
}
