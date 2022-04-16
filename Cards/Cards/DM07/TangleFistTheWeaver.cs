namespace Cards.Cards.DM07
{
    class TangleFistTheWeaver : Creature
    {
        public TangleFistTheWeaver() : base("Tangle Fist, the Weaver", 4, 2000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddTapAbility(new OneShotEffects.YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(3));
        }
    }
}
