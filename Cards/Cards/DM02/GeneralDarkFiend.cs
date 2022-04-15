namespace Cards.Cards.DM02
{
    class GeneralDarkFiend : Creature
    {
        public GeneralDarkFiend() : base("General Dark Fiend", 5, 6000, Engine.Subtype.DarkLord, Common.Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
            AddDoubleBreakerAbility();
        }
    }
}
