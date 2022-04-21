using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect : ManaFeedEffect
    {
        public PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect() : base(1, 1, true)
        {
        }

        public PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect(this);
        }

        public override string ToString()
        {
            return "Put one of your creatures from the battle zone into your mana zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(GetSourceAbility(game).Controller);
        }
    }
}
