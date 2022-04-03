using Common;

namespace Cards.Cards.DM11
{
    class SquawkingLunatron : SilentSkillCreature
    {
        public SquawkingLunatron() : base("Squawking Lunatron", 5, 4000, Subtype.CyberMoon, Civilization.Water)
        {
            AddSilentSkillAbility(new OneShotEffects.ReturnUpToCardsFromYourManaZoneToYourHandEffect(3));
        }
    }
}
