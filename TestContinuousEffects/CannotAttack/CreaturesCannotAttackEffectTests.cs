using ContinuousEffects.CannotAttack;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.CannotAttack;

public class CreaturesCannotAttackEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new CreaturesCannotAttackEffect(filter.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CreatureCannotAttack(bool creatureMatches)
    {
        // Arrangev
        var player = Mock.Of<IPlayerV2>();
        var creature = Mock.Of<ICreature>();
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(creature)).Returns(creatureMatches);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(creature);
        var effect = new CreaturesCannotAttackEffect(filter.Object)
        {
            Ability = ability.Object,
            Applier = player
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.CannotAttack(creature, Mock.Of<IGame>());

        // Assert
        Assert.Equal(creatureMatches, actual);
    }
}