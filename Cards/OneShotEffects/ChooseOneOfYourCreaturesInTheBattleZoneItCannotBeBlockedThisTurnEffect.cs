using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect : CreateContinuousEffectChoiceEffect
    {
        public ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true, new ThisCreatureCannotBeBlockedThisTurnEffect())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect();
        }

        public override string ToString()
        {
            return "Choose one of your creatures in the battle zone. It can't be blocked this turn.";
        }
    }
}
