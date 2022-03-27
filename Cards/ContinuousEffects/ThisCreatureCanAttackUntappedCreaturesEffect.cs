using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCanAttackUntappedCreaturesEffect : CanAttackUntappedCreaturesEffect
    {
        public ThisCreatureCanAttackUntappedCreaturesEffect(ThisCreatureCanAttackUntappedCreaturesEffect effect) : base(effect)
        {
        }

        public ThisCreatureCanAttackUntappedCreaturesEffect() : base(new CardFilters.OpponentsBattleZoneUntappedCreatureFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCanAttackUntappedCreaturesEffect(this);
        }

        public override string ToString()
        {
            return "This creature can attack untapped creatures.";
        }
    }
}