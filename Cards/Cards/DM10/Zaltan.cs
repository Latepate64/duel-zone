using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class Zaltan : Creature
    {
        public Zaltan() : base("Zaltan", 5, 3000, Engine.Subtype.CyberLord, Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutSubtypeCreatureIntoTheBattleZoneAbility(Engine.Subtype.CyberVirus, new ZaltanEffect()));
        }
    }

    class ZaltanEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = new OneShotEffects.DiscardUpToCards(2).Apply(game, source);
            return new OneShotEffects.ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect(cards.Count()).Apply(game, source);
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
