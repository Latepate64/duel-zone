using Common;

namespace Cards.Cards.DM06
{
    public class AutomatedWeaponmasterMachai : Creature
    {
        public AutomatedWeaponmasterMachai() : base("Automated Weaponmaster Machai", 4, Civilization.Fire, 4000, Subtype.Armorloid)
        {
            Abilities.Add(new StaticAbilities.AttacksIfAbleAbility());
        }
    }
}
