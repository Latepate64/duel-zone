using Common;

namespace Cards.Cards.DM08
{
    class CorpseCharger : Charger
    {
        public CorpseCharger() : base("Corpse Charger", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.ReturnCreatureFromYourGraveyardToYourHandEffect());
        }
    }
}
