namespace Cards.Cards.DM02
{
    class BolzardDragon : Creature
    {
        public BolzardDragon() : base("Bolzard Dragon", 6, 5000, Common.Subtype.ArmoredDragon, Common.Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect()));
        }
    }
}
