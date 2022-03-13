using Common;

namespace Cards.Cards.DM02
{
    class ReconOperation : Spell
    {
        public ReconOperation() : base("Recon Operation", 2, Civilization.Water)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.LookEffect(new CardFilters.OpponentsShieldZoneCardFilter(), 0, 3, true)));
        }
    }
}
