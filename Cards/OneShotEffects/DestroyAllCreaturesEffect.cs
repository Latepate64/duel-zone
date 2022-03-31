using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DestroyAllCreaturesEffect : DestroyAreaOfEffect
    {
        public DestroyAllCreaturesEffect() : base(new CardFilters.BattleZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyAllCreaturesEffect();
        }

        public override string ToString()
        {
            return "Destroy all creatures.";
        }
    }
}