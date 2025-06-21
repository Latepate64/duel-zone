namespace Cards.DM07
{
    class MulchCharger : Charger
    {
        public MulchCharger() : base("Mulch Charger", 3, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect());
        }
    }
}
