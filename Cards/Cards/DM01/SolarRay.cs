using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class SolarRay : Spell
    {
        public SolarRay() : base("Solar Ray", 2, Common.Civilization.Light)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
