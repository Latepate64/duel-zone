using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayDestroyCreatureEffect : DestroyEffect
    {
        public YouMayDestroyCreatureEffect() : base(new CardFilters.BattleZoneChoosableCreatureFilter(), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDestroyCreatureEffect();
        }

        public override string ToString()
        {
            return "You may destroy a creature.";
        }
    }
}