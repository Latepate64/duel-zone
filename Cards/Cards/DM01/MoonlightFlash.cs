using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class MoonlightFlash : Spell
    {
        public MoonlightFlash() : base("Moonlight Flash", 4, Common.Civilization.Light)
        {
            AddSpellAbilities(new ChooseUpToOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(2));
        }
    }
}
