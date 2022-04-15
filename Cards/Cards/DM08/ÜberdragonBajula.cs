namespace Cards.Cards.DM08
{
    class ÜberdragonBajula : DragonEvolutionCreature
    {
        public ÜberdragonBajula() : base("Überdragon Bajula", 7, 13000, Engine.Subtype.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseUpToCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect(2));
        }
    }
}
