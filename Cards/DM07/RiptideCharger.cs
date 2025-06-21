namespace Cards.DM07
{
    class RiptideCharger : Charger
    {
        public RiptideCharger() : base("Riptide Charger", 5, Interfaces.Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
