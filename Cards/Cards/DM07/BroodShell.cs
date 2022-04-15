namespace Cards.Cards.DM07
{
    class BroodShell : Creature
    {
        public BroodShell() : base("Brood Shell", 4, 3000, Engine.Subtype.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddTapAbility(new OneShotEffects.ReturnCreatureFromYourManaZoneToYourHandEffect());
        }
    }
}
