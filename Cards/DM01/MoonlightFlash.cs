using OneShotEffects;

namespace Cards.DM01
{
    class MoonlightFlash : Engine.Spell
    {
        public MoonlightFlash() : base("Moonlight Flash", 4, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect());
        }
    }
}
