namespace Cards.Cards.DM02
{
    class ManaCrisis : Spell
    {
        public ManaCrisis() : base("Mana Crisis", 4, Common.Civilization.Nature)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect());
        }
    }
}
