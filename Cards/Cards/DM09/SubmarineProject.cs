using Cards.OneShotEffects;
using Engine;

namespace Cards.Cards.DM09
{
    class SubmarineProject : Spell
    {
        public SubmarineProject() : base("Submarine Project", 3, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect());
        }
    }
}
