using Common;
using Common.Choices;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class Gigandura : Creature
    {
        public Gigandura() : base("Gigandura", 5, 3000, Subtype.Chimera, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new GiganduraEffect());
        }
    }

    class GiganduraEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            source.GetController(game).Look(source.GetOpponent(game), game, source.GetOpponent(game).Hand.Cards.ToArray());
            var cards = source.GetController(game).Choose(new BoundedCardSelectionInEffect(source.GetController(game).Id, source.GetOpponent(game).Hand.Cards, 0, 1, ToString()), game).Decision.Select(x => game.GetCard(x)).ToArray();
            if (cards.Any())
            {
                game.Move(ZoneType.Hand, ZoneType.ManaZone, cards.ToArray());
                new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect().Apply(game, source);
            }
            source.GetOpponent(game).Unreveal(cards);
            return cards;
        }

        public override IOneShotEffect Copy()
        {
            return new GiganduraEffect();
        }

        public override string ToString()
        {
            return "Look at your opponent's hand. You may choose a card in it and put it into his mana zone. If you do, choose a card in his mana zone and put it into his hand.";
        }
    }
}
