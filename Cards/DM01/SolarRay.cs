using OneShotEffects;

namespace Cards.DM01
{
    class SolarRay : Engine.Spell
    {
        public SolarRay() : base("Solar Ray", 2, Engine.Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
