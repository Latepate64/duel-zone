using Common;

namespace Cards.Cards.DM11
{
    class SolarTrap : Spell
    {
        public SolarTrap() : base("Solar Trap", 1, Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
