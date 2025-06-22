namespace Cards.DM07
{
    sealed class MulchCharger : Charger
    {
        public MulchCharger() : base("Mulch Charger", 3, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect());
        }
    }
}
