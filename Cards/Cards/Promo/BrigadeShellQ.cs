using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.Promo
{
    class BrigadeShellQ : Creature
    {
        public BrigadeShellQ() : base("Brigade Shell Q", 3, 1000, Race.Survivor, Race.ColonyBeetle, Civilization.Nature)
        {
            AddSurvivorAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new BrigadeShellQEffect()));
        }
    }

    class BrigadeShellQEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var cards = Controller.RevealTopCardsOfDeck(1, game).ToArray();
            if (cards.Length == 1)
            {
                if (cards.Single().HasRace(Race.Survivor))
                {
                    game.Move(Source, ZoneType.Deck, ZoneType.Hand, cards);
                }
                else
                {
                    game.Move(Source, ZoneType.Deck, ZoneType.Graveyard, cards);
                }
            }
            Controller.Unreveal(cards);
        }

        public override IOneShotEffect Copy()
        {
            return new BrigadeShellQEffect();
        }

        public override string ToString()
        {
            return "Reveal the top card of your deck. If it's a Survivor, put it into your hand. Otherwise, put it into your graveyard.";
        }
    }
}
