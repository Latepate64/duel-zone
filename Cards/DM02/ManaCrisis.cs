namespace Cards.DM02
{
    class ManaCrisis : Engine.Spell
    {
        public ManaCrisis() : base("Mana Crisis", 4, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect());
        }
    }
}
