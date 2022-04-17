namespace Cards.Cards.DM07
{
    class RiptideCharger : Charger
    {
        public RiptideCharger() : base("Riptide Charger", 5, Engine.Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
