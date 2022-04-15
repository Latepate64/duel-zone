namespace Cards.Cards.DM08
{
    class ColiseumShell : Creature
    {
        public ColiseumShell() : base("Coliseum Shell", 4, 3000, Engine.Subtype.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.MayPutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
