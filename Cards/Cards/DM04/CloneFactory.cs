using Common;

namespace Cards.Cards.DM04
{
    class CloneFactory : Spell
    {
        public CloneFactory() : base("Clone Factory", 3, Civilization.Water)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.SelfManaRecoveryEffect(0, 2, true, new CardFilters.OwnersManaZoneCardFilter())));
        }
    }
}
