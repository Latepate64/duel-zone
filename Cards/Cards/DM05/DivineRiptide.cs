using Common;

namespace Cards.Cards.DM05
{
    class DivineRiptide : Spell
    {
        public DivineRiptide() : base("Divine Riptide", 9, Civilization.Water)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.ManaRecoveryAreaOfEffect(new CardFilters.ManaZoneCardFilter())));
        }
    }
}
