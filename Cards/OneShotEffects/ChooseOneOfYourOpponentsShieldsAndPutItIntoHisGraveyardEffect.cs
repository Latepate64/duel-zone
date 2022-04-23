using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect : ShieldBurnEffect
    {
        public ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect() : base(1, 1, true)
        {
        }

        public ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect(ShieldBurnEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's shields and put it into his graveyard.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return GetOpponent(game).ShieldZone.Cards;
        }
    }
}
