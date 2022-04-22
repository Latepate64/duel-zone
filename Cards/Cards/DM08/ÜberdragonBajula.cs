namespace Cards.Cards.DM08
{
    class ÜberdragonBajula : DragonEvolutionCreature
    {
        public ÜberdragonBajula() : base("Überdragon Bajula", 7, 13000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseUpToTwoCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect());
        }
    }
}
