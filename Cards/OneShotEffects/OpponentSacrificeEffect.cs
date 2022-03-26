using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class OpponentSacrificeEffect : DestroyEffect
    {
        public OpponentSacrificeEffect() : base(new CardFilters.OpponentsBattleZoneCreatureFilter(), 1, 1, false)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new OpponentSacrificeEffect();
        }

        public override string ToString()
        {
            return "Your opponent chooses one of his creatures and destroys it.";
        }
    }
}
