using Common;

namespace Cards.Cards.DM08
{
    class ColiseumShell : Creature
    {
        public ColiseumShell() : base("Coliseum Shell", 4, 3000, Subtype.ColonyBeetle, Civilization.Nature)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.MayPutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
