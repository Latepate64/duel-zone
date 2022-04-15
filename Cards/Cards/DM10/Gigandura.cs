using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    class Gigandura : Creature
    {
        public Gigandura() : base("Gigandura", 5, 3000, Engine.Subtype.Chimera, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new GiganduraEffect());
        }
    }

    class GiganduraEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            source.GetController(game).Look(source.GetOpponent(game), game, source.GetOpponent(game).Hand.Cards.ToArray());
            var card = source.GetController(game).ChooseCardOptionally(source.GetOpponent(game).Hand.Cards, ToString());
            if (card != null)
            {
                game.Move(ZoneType.Hand, ZoneType.ManaZone, card);
                new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect().Apply(game, source);
            }
            source.GetOpponent(game).Unreveal(new List<ICard> { card });
            return card;
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
