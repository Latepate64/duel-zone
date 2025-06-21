using OneShotEffects;

namespace Cards.DM01
{
    class MoonlightFlash : Engine.Spell
    {
        public MoonlightFlash() : base("Moonlight Flash", 4, Engine.Civilization.Light)
        {
            AddSpellAbilities(new ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect());
        }
    }
}
