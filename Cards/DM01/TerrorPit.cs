using OneShotEffects;

namespace Cards.DM01
{
    sealed class TerrorPit : Spell
    {
        public TerrorPit() : base("Terror Pit", 6, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DestroyOneOfYourOpponentsCreaturesEffect());
        }
    }
}
