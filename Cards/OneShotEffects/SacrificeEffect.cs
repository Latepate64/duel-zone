using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class SacrificeEffect : DestroyEffect
    {
        public SacrificeEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SacrificeEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your creatures.";
        }
    }
}
