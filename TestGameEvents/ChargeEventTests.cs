using GameEvents;
using Interfaces;
using Interfaces.Zones;
using Moq;

namespace TestGameEvents;

public class ChargeEventTests
{
    [Fact]
    public void CopyEqualsOriginalWithCard()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var card = new Mock<ICard>();
        card.Setup(x => x.Copy()).Returns(card.Object);
        var chargeEvent = new ChargeEvent(player.Object) {
            ChosenCard = card.Object };

        // Act
        var actual = chargeEvent.Copy();
        
        // Assert
        Assert.Equal(chargeEvent, actual);
    }

    [Fact]
    public void CopyEqualsOriginalWithoutCard()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var chargeEvent = new ChargeEvent(player.Object);

        // Act
        var actual = chargeEvent.Copy();
        
        // Assert
        Assert.Equal(chargeEvent, actual);
    }

    [Fact]
    public void ValidationThrowsForUnexpectedType()
    {
        // Arrange
        var charge = new ChargeEvent(Mock.Of<IPlayerV2>());

        // Act
        var ex = Assert.Throws<IllegalActionException>(
            () => charge.Validate(Mock.Of<IPassableGameEvent>()));

        // Assert
        Assert.Equal(IllegalActionType.UnexpectedType, ex.Type);
    }

    [Fact]
    public void ValidationThrowsWhenChosenCardIsNull()
    {
        // Arrange
        var charge = new ChargeEvent(Mock.Of<IPlayerV2>());

        // Act
        var ex = Assert.Throws<IllegalActionException>(
            () => charge.Validate(charge));

        // Assert
        Assert.Equal(IllegalActionType.ChosenCardIsNull, ex.Type);
    }

    [Fact]
    public void ValidationThrowsWhenChosenCardIsNotInHand()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Hand.Cards).Returns([]);
        var charge = new ChargeEvent(player.Object)
        {
            ChosenCard = Mock.Of<ICard>()
        };

        // Act
        var ex = Assert.Throws<IllegalActionException>(
            () => charge.Validate(charge));

        // Assert
        Assert.Equal(IllegalActionType.HandDoesNotContainCard, ex.Type);
    }

    [Fact]
    public void ValidationSucceedsWhenChosenCardIsInHand()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        var card = new Mock<ICard>();
        player.Setup(x => x.Hand.Contains(card.Object)).Returns(true);
        var charge = new ChargeEvent(player.Object)
        {
            ChosenCard = card.Object
        };

        // Act + Assert
        charge.Validate(charge);
    }

    [Fact]
    public void DoesNotEqualNull()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var charge = new ChargeEvent(player);

        // Act
        var actual = charge.Equals(null);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualEventOfAnotherType()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var charge = new ChargeEvent(player);
        var attack = new AttackEvent(player);

        // Act
        var actual = charge.Equals(attack);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualChargeEventWithDifferentCard()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        var charge = new ChargeEvent(player.Object);
        var another = new ChargeEvent(player.Object)
        {
            ChosenCard = Mock.Of<ICard>()
        };

        // Act
        var actual = charge.Equals(another);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void HashCodeIsNotZero(bool chosenCard)
    {
        // Arrange
        var charge = new ChargeEvent(Mock.Of<IPlayerV2>())
        {
            ChosenCard = chosenCard ? Mock.Of<ICard>() : null
        };

        // Act
        var actual = charge.GetHashCode();

        // Assert
        Assert.NotEqual(0, actual);
    }

    [Fact]
    public void ChargingWithoutChosenCardReturnsNoEvents()
    {
        // Arrange
        var charge = new ChargeEvent(Mock.Of<IPlayerV2>());
        var state = Mock.Of<IGameState>();

        // Act
        var events = charge.Happen(state);

        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void ChargedCardIsRemovedFromHandAndAddedIntoManaZone()
    {
        // Arrange
        var card = Mock.Of<ICard>();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Hand).Returns(Mock.Of<IHand>());
        player.SetupGet(x => x.ManaZone).Returns(Mock.Of<IManaZone>());
        var charge = new ChargeEvent(player.Object)
        {
            ChosenCard = card
        };
        var state = Mock.Of<IGameState>();

        // Act
        var events = charge.Happen(state);

        // Assert
        Assert.Empty(events);
        player.Verify(x => x.Hand.Remove(card));
        player.Verify(x => x.ManaZone.Add(card));
    }
}