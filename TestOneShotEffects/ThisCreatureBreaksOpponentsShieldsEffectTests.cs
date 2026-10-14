using Interfaces;
using Moq;
using OneShotEffects;

namespace TestOneShotEffects;

public class ThisCreatureBreaksOpponentsShieldsEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new ThisCreatureBreaksOpponentsShieldsEffect(1);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEffects()
    {
        // Arrange
        var effect = new ThisCreatureBreaksOpponentsShieldsEffect(1);
        var copy = effect.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = effect.GetHashCode();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Breaks(int amount)
    {
        // Arrange
        var controller = new Mock<IPlayer>();
        var source = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(controller.Object);
        ability.SetupGet(x => x.Source).Returns(source);
        var effect = new ThisCreatureBreaksOpponentsShieldsEffect(amount)
        {
            Ability = ability.Object,
        };
        var game = new Mock<IGame>();

        // Act
        effect.Apply(game.Object);

        // Assert
        game.Verify(x => x.Break(source, amount));
    }
}