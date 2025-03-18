using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Moq;
using Xunit;

namespace TestCards.OneShotEffects;

public class YouMayDrawCardsEffectTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void LetsPlayerDrawCardsOptionally(int maximum)
    {
        // Arrange
        var effect = new YouMayDrawCardsEffect(maximum);
        var ability = Mock.Of<IAbility>();
        var player = new Mock<IPlayer>();
        ability.Controller = player.Object;
        effect.Ability = ability;
        var game = Mock.Of<IGame>();

        // Act
        effect.Apply(game);

        // Assert
        player.Verify(x => x.DrawCardsOptionally(game, ability, maximum),
            Times.Once);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Copy(int maximum)
    {
        var effect = new YouMayDrawCardsEffect(maximum);
        var copy = effect.Copy();
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void NotEqual()
    {
         Assert.NotEqual(
            new YouMayDrawCardsEffect(1),
            new YouMayDrawCardsEffect(2));
    }
}