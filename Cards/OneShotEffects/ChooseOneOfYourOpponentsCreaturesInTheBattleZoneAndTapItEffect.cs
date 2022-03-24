using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect : TapChoiceEffect
    {
        public ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect(ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect effect) : base(effect)
        {
        }

        public ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect() : base(1, 1, true)
        {
        }

        public override OneShotEffect Copy()
        {
            return new ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone and tap it.";
        }
    }
}
