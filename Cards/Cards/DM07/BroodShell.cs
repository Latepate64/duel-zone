using Common;

namespace Cards.Cards.DM07
{
    class BroodShell : Creature
    {
        public BroodShell() : base("Brood Shell", 4, 3000, Subtype.ColonyBeetle, Civilization.Nature)
        {
            AddTapAbility(new OneShotEffects.ReturnCreatureFromYourManaZoneToYourHandEffect());
        }
    }
}
