using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect : BounceEffect
    {
        public ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect() : base(new CardFilters.BattleZoneCreatureFilter(), 0, 2)
        {
        }

        public override OneShotEffect Copy()
        {
            return new ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect();
        }

        public override string ToString()
        {
            return "Choose up to 2 creatures in the battle zone and return them to their owners' hands.";
        }
    }
}
