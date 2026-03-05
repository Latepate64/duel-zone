namespace Cards.DM02
{
    sealed class ManaCrisis : Spell
    {
        public ManaCrisis() : base("Mana Crisis", 4, Interfaces.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect());
        }
    }
}
