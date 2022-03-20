using Common;

namespace Cards.Cards.DM05
{
    class DivineRiptide : Spell
    {
        public DivineRiptide() : base("Divine Riptide", 9, Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.ManaRecoveryAreaOfEffect(new CardFilters.ManaZoneCardFilter()));
        }
    }
}
