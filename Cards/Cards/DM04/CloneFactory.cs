using Common;

namespace Cards.Cards.DM04
{
    class CloneFactory : Spell
    {
        public CloneFactory() : base("Clone Factory", 3, Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.SelfManaRecoveryEffect(0, 2, true, new CardFilters.OwnersManaZoneCardFilter()));
        }
    }
}
