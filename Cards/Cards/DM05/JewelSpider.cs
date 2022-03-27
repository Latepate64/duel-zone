using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM05
{
    class JewelSpider : Creature
    {
        public JewelSpider() : base("Jewel Spider", 2, 1000, Subtype.BrainJacker, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.DestroyedAbility(new YouMayChooseOneOfYourShieldsAndPutItIntoYourHandEffect()));
        }
    }

    class YouMayChooseOneOfYourShieldsAndPutItIntoYourHandEffect : ShieldRecoveryEffect
    {
        public YouMayChooseOneOfYourShieldsAndPutItIntoYourHandEffect(YouMayChooseOneOfYourShieldsAndPutItIntoYourHandEffect effect) : base(effect)
        {
        }

        public YouMayChooseOneOfYourShieldsAndPutItIntoYourHandEffect() : base(new CardFilters.OwnersShieldZoneCardFilter(), 0, 1, true, false)
        {
        }

        public override string ToString()
        {
            return "You may choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.";
        }
    }
}
