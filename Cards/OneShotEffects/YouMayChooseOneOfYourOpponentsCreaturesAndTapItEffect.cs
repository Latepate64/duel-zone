using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect : TapChoiceEffect
    {
        public YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect() : base(0, 1, true)
        {
        }

        public YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect(YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect(this);
        }

        public override string ToString()
        {
            return "You may choose one of your opponent's creatures in the battle zone and tap it.";
        }
    }
}