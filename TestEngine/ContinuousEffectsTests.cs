using Engine.ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using Moq;
using Xunit;

namespace TestEngine;

public sealed class ContinuousEffectsTests
{
    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var effects = new ContinuousEffects(Mock.Of<IGame>());
        var continuousEffect = new Mock<IContinuousEffect>();
        continuousEffect.Setup(x => x.Copy()).Returns(
            continuousEffect.Object);
        effects.Add(Mock.Of<IAbility>(), continuousEffect.Object);
        var another = effects.Copy();

        // Act
        var expected = effects.GetHashCode();
        var actual = another.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var effects = new ContinuousEffects(Mock.Of<IGame>());

        // Act
        var actual = effects.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void DoesNotEqualObjectWithDifferentGame(
        bool firstNull, bool secondNull)
    {
        // Arrange
        var first = new ContinuousEffects(firstNull ? null : Mock.Of<IGame>());
        var second = new ContinuousEffects(
            secondNull ? null : Mock.Of<IGame>());

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualObjectWithDifferentEffects()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var first = new ContinuousEffects(game);
        first.Add(Mock.Of<IAbility>(), Mock.Of<IContinuousEffect>());
        var second = new ContinuousEffects(game);

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void ObjectsAreEqual()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var first = new ContinuousEffects(game);
        var second = new ContinuousEffects(game);

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void CopyOfEffectsGetsAbilityReferenceAndTimestamp()
    {
        // Arrange
        var effects = new ContinuousEffects(Mock.Of<IGame>());
        var source = Mock.Of<ICard>();
        var staticAbility = new Mock<IStaticAbility>();
        var effect = new Mock<IContinuousEffect>();
        effect.Setup(x => x.Copy()).Returns(effect.Object);
        staticAbility.SetupGet(x => x.ContinuousEffects).Returns([
            effect.Object]);

        // Act
        effects.Add(source, staticAbility.Object);

        // Assert
        effect.VerifySet((x) => x.Ability = staticAbility.Object);
        effect.VerifySet((x) => x.Timestamp = source.Timestamp);
    }

    [Fact]
    public void Apply()
    {
        // Arrange
        var game = new Mock<IGame>();
        var card = new Mock<ICard>();
        game.Setup(x => x.GetAllCards()).Returns([card.Object]);
        var effects = new ContinuousEffects(game.Object);
        var raceAddingEffect = new Mock<IRaceAddingEffect>();
        var abilityAddingEffect = new Mock<IAbilityAddingEffect>();
        var powerModifyingEffect = new Mock<IPowerModifyingEffect>();
        effects.Add(
            Mock.Of<IAbility>(),
            raceAddingEffect.Object,
            abilityAddingEffect.Object,
            powerModifyingEffect.Object);

        // Act
        effects.Apply();

        // Assert
        card.Verify(x => x.ResetToPrintedValues());
        raceAddingEffect.Verify(x => x.AddRace(game.Object));
        abilityAddingEffect.Verify(x => x.AddAbility(game.Object));
        powerModifyingEffect.Verify(x => x.ModifyPower(game.Object));
    }
}