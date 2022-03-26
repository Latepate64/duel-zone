using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class ReconOperation : Spell
    {
        public ReconOperation() : base("Recon Operation", 2, Civilization.Water)
        {
            AddSpellAbilities(new ReconOperationEffect());
        }
    }

    class ReconOperationEffect : OneShotEffects.LookEffect
    {
        public ReconOperationEffect() : base(new CardFilters.OpponentsShieldZoneCardFilter(), 0, 3)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReconOperationEffect();
        }

        public override string ToString()
        {
            return "Look at up to 3 of your opponent's shields.";
        }
    }
}
