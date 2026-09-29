using GameEvents;
using Interfaces;
using Interfaces.Zones;
using Moq;

namespace TestGameEvents;

public class UseCardEventTests
{
    [Fact]
    public void CopyEqualsOriginalWithCardAndPaymentCards()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var card = new Mock<ICard>();
        card.Setup(x => x.Copy()).Returns(card.Object);
        var useCardEvent = new UseCardEvent(player.Object)
        {
            Card = card.Object,
            PaymentCards = [card.Object]
        };

        // Act
        var actual = useCardEvent.Copy();
        
        // Assert
        Assert.Equal(useCardEvent, actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var useCardEvent = new UseCardEvent(player.Object);

        // Act
        var actual = useCardEvent.Copy();
        
        // Assert
        Assert.Equal(useCardEvent, actual);
    }

    [Fact]
    public void DoesNotEqualNull()
    {
        // Arrange
        var use = new UseCardEvent(Mock.Of<IPlayerV2>());

        // Act
        var actual = use.Equals(null);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualEventOfAnotherType()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var use = new UseCardEvent(player);
        var attack = new AttackEvent(player);

        // Act
        var actual = use.Equals(attack);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DoesNotEqualUseCardEventWithDifferentCards(
        bool cardInsteadOfPaymentCards)
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        var use = new UseCardEvent(player.Object);
        var another = new UseCardEvent(player.Object)
        {
            Card = cardInsteadOfPaymentCards ? Mock.Of<ICard>() : null,
            PaymentCards = !cardInsteadOfPaymentCards ? [Mock.Of<ICard>()] : []
        };

        // Act
        var actual = use.Equals(another);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualUseCardEventThatShouldEnd()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        var creature = Mock.Of<ICreature>();
        var use = new UseCardEvent(player.Object)
        {
            Card = creature
        };
        var another = new UseCardEvent(player.Object)
        {
            Card = creature
        };
        use.Happen(Mock.Of<IGameState>());

        // Act
        var actual = use.Equals(another);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void ValidationThrowsForUnexpectedType()
    {
        // Arrange
        var use = new UseCardEvent(Mock.Of<IPlayerV2>());

        // Act
        var ex = Assert.Throws<IllegalActionException>(
            () => use.Validate(Mock.Of<IPassableGameEvent>()));

        // Assert
        Assert.Equal(IllegalActionType.UnexpectedType, ex.Type);
    }

    [Fact]
    public void ValidationSucceedsWhenNoCardIsUsed()
    {
        // Arrange
        var use = new UseCardEvent(Mock.Of<IPlayerV2>());

        // Act + Assert
        use.Validate(use);
    }

    [Fact]
    public void ValidationThrowsWhenHandDoesNotContainCardToBeUsed()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Hand.Contains(It.IsAny<ICard>())).Returns(false);
        var use = new UseCardEvent(player.Object)
        {
            Card = Mock.Of<ICard>()
        };

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => use.Validate(use));

        // Assert
        Assert.Equal(IllegalActionType.HandDoesNotContainCard, ex.Type);
    }

    [Theory]
    [InlineData(IllegalActionType.UseCardTappedManaForPayment)]
    [InlineData(IllegalActionType.UseCardPaymentForManaCost)]
    [InlineData(IllegalActionType.UseCardPaymentForCivilizations)]
    public void ValidationThrowsWhenPaymentIsIllegal(
        IllegalActionType illegalActionType)
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        var useCard = new Mock<ICard>();
        useCard.SetupGet(x => x.ManaCost).Returns(
            illegalActionType == IllegalActionType.UseCardPaymentForManaCost
                ? 2 : 1);
        useCard.SetupGet(x => x.Civilizations).Returns([Civilization.Light]);
        player.Setup(x => x.Hand.Contains(useCard.Object)).Returns(true);
        var manaCard = new Mock<ICard>();
        manaCard.SetupGet(x => x.Tapped).Returns(
            illegalActionType == IllegalActionType.UseCardTappedManaForPayment);
        manaCard.SetupGet(x => x.Civilizations).Returns([Civilization.Water]);
        var use = new UseCardEvent(player.Object)
        {
            Card = useCard.Object,
            PaymentCards = [manaCard.Object]
        };

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => use.Validate(use));

        // Assert
        Assert.Equal(illegalActionType, ex.Type);
    }

    [Fact]
    public void ValidationSucceedsWhenCardIsUsedLegally()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        var useCard = new Mock<ICard>();
        useCard.SetupGet(x => x.ManaCost).Returns(1);
        useCard.SetupGet(x => x.Civilizations).Returns([]);
        player.Setup(x => x.Hand.Contains(useCard.Object)).Returns(true);
        var manaCard = new Mock<ICard>();
        manaCard.SetupGet(x => x.Tapped).Returns(false);
        manaCard.SetupGet(x => x.Civilizations).Returns([]);
        var use = new UseCardEvent(player.Object)
        {
            Card = useCard.Object,
            PaymentCards = [manaCard.Object]
        };

        // Act + Assert
        use.Validate(use);
    }

    [Fact]
    public void HashCodeIsNotZero()
    {
        // Arrange
        var use = new UseCardEvent(Mock.Of<IPlayerV2>());

        // Act
        var actual = use.GetHashCode();

        // Assert
        Assert.NotEqual(0, actual);
    }

    [Fact]
    public void NothingHappensWhenNoCardIsUsed()
    {
        // Arrange
        var use = new UseCardEvent(Mock.Of<IPlayerV2>());

        // Act
        var eventsBeforePass = use.Happen(Mock.Of<IGameState>());
        var eventsAfterPass = use.Happen(Mock.Of<IGameState>());

        // Assert
        Assert.Empty(eventsBeforePass);
        Assert.Empty(eventsAfterPass);
    }

    [Fact]
    public void PlayerSummonsACreature()
    {
        // Arrange
        var mana = Mock.Of<ICard>();
        var use = new UseCardEvent(Mock.Of<IPlayerV2>())
        {
            Card = Mock.Of<ICreature>(),
            PaymentCards = [mana]
        };

        // Act
        var events = use.Happen(Mock.Of<IGameState>());

        // Assert
        Assert.Contains(
            events, x => x.GetType() == typeof(PutIntoBattleZoneEvent));
        Assert.True(mana.Tapped);
    }

    [Fact]
    public void PlayerCastsASpell()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Hand).Returns(Mock.Of<IHand>());
        var spell = Mock.Of<ISpell>();
        var use = new UseCardEvent(player.Object)
        {
            Card = spell
        };

        // Act
        var events = use.Happen(Mock.Of<IGameState>());

        // Assert
        Assert.Contains(
            events, x => x.GetType() == typeof(PutIntoGraveyardEvent));
        player.Verify(x => x.Hand.Remove(spell));
    }

    [Fact]
    public void UsingCardOfUnsupportedTypeThrowsInvalidOperationException()
    {
        // Arrange
        var spell = Mock.Of<ISpell>();
        var use = new UseCardEvent(Mock.Of<IPlayerV2>())
        {
            Card = Mock.Of<ICard>()
        };

        // Act + Assert
        _ = Assert.Throws<InvalidOperationException>(
            () => use.Happen(Mock.Of<IGameState>()));
    }
}