using OneShotEffects;

namespace Cards.DM01
{
    class TerrorPit : Engine.Spell
    {
        public TerrorPit() : base("Terror Pit", 6, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DestroyOneOfYourOpponentsCreaturesEffect());
        }
    }
}
