using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class BroodShell : Engine.Creature
    {
        public BroodShell() : base("Brood Shell", 4, 3000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ReturnCreatureFromYourManaZoneToYourHandEffect()));
        }
    }
}
