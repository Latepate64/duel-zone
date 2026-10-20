using ContinuousEffects;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects;

public class ThisCreatureCannotBeAttackedEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new ThisCreatureCannotBeAttackedEffect(filter.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void ThisCreatureCannotBeAttackedIfAttackerMatches(bool attackerMatches)
    {
        // Arrange
        var targetOfAttack = new Mock<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(targetOfAttack.Object);
        var attacker = Mock.Of<ICreature>();
        var attackerFilter = new Mock<ICardFilter>();
        attackerFilter.Setup(x => x.Match(attacker)).Returns(attackerMatches);
        var effect = new ThisCreatureCannotBeAttackedEffect(attackerFilter.Object)
        {
            Ability = ability.Object
        };

        // Act
        var actual = effect.Applies(attacker, targetOfAttack.Object);

        // Assert
        Assert.Equal(attackerMatches, actual);
    }
}