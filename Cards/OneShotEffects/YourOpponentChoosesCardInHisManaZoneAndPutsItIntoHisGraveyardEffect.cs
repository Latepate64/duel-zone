using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect : ManaBurnEffect
    {
        public YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect() : base(1, 1, false)
        {
        }

        public YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect(YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect(this);
        }

        public override string ToString()
        {
            return $"Your opponent chooses {(Minimum > 1 ? $"{Minimum} cards" : "a card")} in his mana zone and puts {(Minimum > 1 ? "them" : "it")} into his graveyard.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return GetOpponent(game).ManaZone.Cards;
        }
    }
}
