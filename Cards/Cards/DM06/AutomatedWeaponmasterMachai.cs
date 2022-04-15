namespace Cards.Cards.DM06
{
    class AutomatedWeaponmasterMachai : Creature
    {
        public AutomatedWeaponmasterMachai() : base("Automated Weaponmaster Machai", 4, 4000, Engine.Subtype.Armorloid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureAttacksEachTurnIfAbleEffect());
        }
    }
}
