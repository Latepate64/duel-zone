using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM05
{
    class JewelSpider : Creature
    {
        public JewelSpider() : base("Jewel Spider", 2, 1000, Race.BrainJacker, Civilization.Darkness)
        {
            AddWhenThisCreatureIsDestroyedAbility(new YouMayChooseOneOfYourShieldsAndPutItIntoYourHandEffect());
        }
    }

    class YouMayChooseOneOfYourShieldsAndPutItIntoYourHandEffect : ShieldRecoveryEffect
    {
        public YouMayChooseOneOfYourShieldsAndPutItIntoYourHandEffect() : base(0, 1, true, false)
        {
        }

        public override string ToString()
        {
            return "You may choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.";
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayChooseOneOfYourShieldsAndPutItIntoYourHandEffect();
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Applier.ShieldZone.Cards;
        }
    }
}
