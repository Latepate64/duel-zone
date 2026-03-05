using OneShotEffects;

namespace Cards.DM01
{
    sealed class MoonlightFlash : Spell
    {
        public MoonlightFlash() : base("Moonlight Flash", 4, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect());
        }
    }
}
