namespace Cards.Cards.DM02
{
    class BolzardDragon : Creature
    {
        public BolzardDragon() : base("Bolzard Dragon", 6, 5000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect());
        }
    }
}
