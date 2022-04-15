namespace Cards.Cards.DM08
{
    class CorpseCharger : Charger
    {
        public CorpseCharger() : base("Corpse Charger", 4, Engine.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.ReturnCreatureFromYourGraveyardToYourHandEffect());
        }
    }
}
