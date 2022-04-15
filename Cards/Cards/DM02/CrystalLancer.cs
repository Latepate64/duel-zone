using Common;

namespace Cards.Cards.DM02
{
    class CrystalLancer : EvolutionCreature
    {
        public CrystalLancer() : base("Crystal Lancer", 6, 8000, Engine.Subtype.LiquidPeople, Civilization.Water)
        {
            AddThisCreatureCannotBeBlockedAbility();
            AddDoubleBreakerAbility();
        }
    }
}
