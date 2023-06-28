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
        public ZaltanEffect()
        {
        }

        public ZaltanEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var cards = Applier.ChooseCards(Applier.Hand.Cards, 0, 2, ToString());
            game.Move(Ability, ZoneType.Hand, ZoneType.Graveyard, cards.ToArray());
            var creatures = Applier.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, Applier), cards.Count(), cards.Count(), ToString());
            game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, creatures.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new ZaltanEffect(this);
        }

        public override string ToString()
        {
            return "You may discard up to 2 cards from your hand. For each card you discard, choose a creature in the battle zone and return it to its owner's hand.";
        }
    }
}
