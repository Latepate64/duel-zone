namespace Cards.Cards.DM02
{
    class GeneralDarkFiend : Creature
    {
        public GeneralDarkFiend() : base("General Dark Fiend", 5, 6000, Common.Subtype.DarkLord, Common.Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
