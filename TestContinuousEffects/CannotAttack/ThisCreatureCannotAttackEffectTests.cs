using ContinuousEffects.CannotAttack;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CannotAttack;

public class ThisCreatureCannotAttackEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var condition = new Mock<ICondition>();
        condition.Setup(x => x.Copy()).Returns(condition.Object);
        var effect = new ThisCreatureCannotAttackEffect(condition.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CreatureCannotAttack(bool conditionMet)
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(creature);
        var condition = new Mock<ICondition>();
        condition.Setup(x => x.IsMet(creature)).Returns(conditionMet);
        var effect = new ThisCreatureCannotAttackEffect(condition.Object)
        {
            Ability = ability.Object
        };

        // Act
        var actual = effect.CannotAttack(creature, Mock.Of<IGame>());

        // Assert
        Assert.Equal(conditionMet, actual);
    }
}