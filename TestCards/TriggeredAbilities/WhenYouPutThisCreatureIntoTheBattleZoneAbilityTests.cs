using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using System;
using Xunit;

namespace TestCards.TriggeredAbilities
{
    public class WhenYouPutThisCreatureIntoTheBattleZoneAbilityTests
    {
        [Fact]
        public void CanTrigger_CardMovesToBattleZone_ReturnTrue()
        {
            var card = new Card();
            Assert.True(
                new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffectMock())
                {
                    Source = card.Id
                }.CanTrigger(
                    new CardMovedEventMock(ZoneType.BattleZone)
                    {
                        Card = card
                    },
                    new Game()));
        }
    }

    class CardMovedEventMock : ICardMovedEvent
    {
        public IPlayer Player { get; }
        public Guid CardInSourceZone { get; }
        public ZoneType Source { get; }
        public ZoneType Destination { get; }
        public bool EntersTapped { get; }
        public ICard Card { get; set; }
        public Guid Id { get; }

        public IPlayer GetApplier(IGame game)
        {
            throw new NotImplementedException();
        }

        public void Happen(IGame game)
        {
            throw new NotImplementedException();
        }

        public CardMovedEventMock(ZoneType destination)
        {
            Destination = destination;
        }
    }

    class OneShotEffectMock : IOneShotEffect
    {
        public object Apply(IGame game, IAbility source)
        {
            throw new NotImplementedException();
        }

        public IOneShotEffect Copy()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
