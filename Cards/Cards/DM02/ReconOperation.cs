using Common;

namespace Cards.Cards.DM02
{
    class ReconOperation : Spell
    {
        public ReconOperation() : base("Recon Operation", 2, Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.LookEffect(new CardFilters.OpponentsShieldZoneCardFilter(), 0, 3, true));
        }
    }
}
