using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class Zaltan : Creature
    {
        public Zaltan() : base("Zaltan", 5, 3000, Race.CyberLord, Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(Race.CyberVirus, new ZaltanEffect()));
        }
    }

    class ZaltanEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var player = source.GetController(game);
            var cards = player.ChooseCards(player.Hand.Cards, 0, 2, ToString());
            game.Move(source, ZoneType.Hand, ZoneType.Graveyard, cards.ToArray());
            new OneShotEffects.ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect(cards.Count()).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ZaltanEffect();
        }

        public override string ToString()
        {
            return "You may discard up to 2 cards from your hand. For each card you discard, choose a creature in the battle zone and return it to its owner's hand.";
        }
    }
}
