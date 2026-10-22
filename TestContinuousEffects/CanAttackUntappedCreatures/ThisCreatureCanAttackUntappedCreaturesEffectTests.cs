using ContinuousEffects.CanAttackUntappedCreatures;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CanAttackUntappedCreatures;

public class ThisCreatureCanAttackUntappedCreaturesEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new ThisCreatureCanAttackUntappedCreaturesEffect(filter.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void ThisCreatureCanAttackMatchingUntappedCreature(bool targetMatches)
    {
        // Arrange
        var targetOfAttack = Mock.Of<ICreature>();
        var attacker = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker);
        var attackerFilter = new Mock<ICardFilter>();
        attackerFilter.Setup(x => x.Match(targetOfAttack)).Returns(targetMatches);
        var effect = new ThisCreatureCanAttackUntappedCreaturesEffect(attackerFilter.Object)
        {
            Ability = ability.Object
        };

        // Act
        var actual = effect.CanAttackUntappedCreature(
            attacker, targetOfAttack, Mock.Of<IGame>());

        // Assert
        Assert.Equal(targetMatches, actual);
    }
}