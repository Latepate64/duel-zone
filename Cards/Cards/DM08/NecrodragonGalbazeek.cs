namespace Cards.Cards.DM08
{
    class NecrodragonGalbazeek : Creature
    {
        public NecrodragonGalbazeek() : base("Necrodragon Galbazeek", 6, 9000, Engine.Subtype.ZombieDragon, Engine.Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
            AddDoubleBreakerAbility();
        }
    }
}
