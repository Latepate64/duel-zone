using Common;

namespace Cards.Cards.DM06
{
    class AutomatedWeaponmasterMachai : Creature
    {
        public AutomatedWeaponmasterMachai() : base("Automated Weaponmaster Machai", 4, 4000, Subtype.Armorloid, Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureAttacksEachTurnIfAbleEffect());
        }
    }
}
