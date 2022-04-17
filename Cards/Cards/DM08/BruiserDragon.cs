namespace Cards.Cards.DM08
{
    class BruiserDragon : Creature
    {
        public BruiserDragon() : base("Bruiser Dragon", 5, 5000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }
}
