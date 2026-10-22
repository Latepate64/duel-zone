using ContinuousEffects.CannotAttackPlayers;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CannotAttackPlayers;

public class ThisCreatureCannotAttackPlayersEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new ThisCreatureCannotAttackPlayersEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void AttackerCannotAttackPlayers()
    {
        // Arrange
        var attacker = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker);
        var effect = new ThisCreatureCannotAttackPlayersEffect()
        {
            Ability = ability.Object
        };

        // Act
        var actual = effect.CannotAttackPlayers(attacker, Mock.Of<IGame>());

        // Assert
        Assert.True(actual);
    }
}