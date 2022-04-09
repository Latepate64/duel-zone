using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect : ShieldBurnEffect
    {
        public ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect() : base(1, 1, true) { }

        public override IOneShotEffect Copy()
        {
            return new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect();
        }

        public override string ToString()
        {
            return "Choose one of your shields and put it into your graveyard.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).ShieldZone.Cards;
        }
    }
}
