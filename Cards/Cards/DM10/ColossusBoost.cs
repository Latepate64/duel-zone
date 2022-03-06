using Common;

namespace Cards.Cards.DM10
{
    class ColossusBoost : Spell
    {
        public ColossusBoost() : base("Colossus Boost", 1, Civilization.Fire)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.GrantPowerChoiceEffect(4000)));
        }
    }
}
