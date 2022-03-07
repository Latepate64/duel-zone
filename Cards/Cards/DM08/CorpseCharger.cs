using Common;

namespace Cards.Cards.DM08
{
    class CorpseCharger : Spell
    {
        public CorpseCharger() : base("Corpse Charger", 4, Civilization.Darkness)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.SalvageCreatureEffect(1, 1)), new StaticAbilities.ChargerAbility());
        }
    }
}
