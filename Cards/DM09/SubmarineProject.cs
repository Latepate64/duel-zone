using OneShotEffects;
using Interfaces;

namespace Cards.DM09
{
    sealed class SubmarineProject : Spell
    {
        public SubmarineProject() : base("Submarine Project", 3, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect());
        }
    }
}
