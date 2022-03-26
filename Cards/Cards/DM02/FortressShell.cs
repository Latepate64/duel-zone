namespace Cards.Cards.DM02
{
    class FortressShell : Creature
    {
        public FortressShell() : base("Fortress Shell", 9, 5000, Common.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpToCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect(2)));
        }
    }
}
