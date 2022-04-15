using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class TerrorPit : Spell
    {
        public TerrorPit() : base("Terror Pit", 6, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DestroyOneOfYourOpponentsCreaturesEffect());
        }
    }
}
