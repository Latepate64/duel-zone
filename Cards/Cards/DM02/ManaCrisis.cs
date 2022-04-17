namespace Cards.Cards.DM02
{
    class ManaCrisis : Spell
    {
        public ManaCrisis() : base("Mana Crisis", 4, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect());
        }
    }
}
