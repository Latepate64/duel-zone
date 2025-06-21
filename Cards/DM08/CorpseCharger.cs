namespace Cards.DM08
{
    class CorpseCharger : Charger
    {
        public CorpseCharger() : base("Corpse Charger", 4, Interfaces.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.ReturnCreatureFromYourGraveyardToYourHandEffect());
        }
    }
}
