using OneShotEffects;

namespace Cards.DM01
{
    sealed class SolarRay : Engine.Spell
    {
        public SolarRay() : base("Solar Ray", 2, Interfaces.Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
