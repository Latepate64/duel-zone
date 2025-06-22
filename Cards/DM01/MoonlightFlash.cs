using OneShotEffects;

namespace Cards.DM01
{
    sealed class MoonlightFlash : Engine.Spell
    {
        public MoonlightFlash() : base("Moonlight Flash", 4, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect());
        }
    }
}
