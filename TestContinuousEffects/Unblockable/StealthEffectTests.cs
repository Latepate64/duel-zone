using ContinuousEffects.Unblockable;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Unblockable;

public class StealthEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new StealthEffect(Civilization.Light);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CannotBeBlocked(bool hasAnyCivilizationCard)
    {
        // Arrange
        var opponent = new Mock<IPlayerV2>();
        opponent.Setup(x => x.ManaZone.HasAnyCivilizationCard(Civilization.Light)).Returns(
            hasAnyCivilizationCard);
        var applier = new Mock<IPlayerV2>();
        applier.SetupGet(x => x.Opponent).Returns(opponent.Object);
        var attacker = new Mock<ICreature>();
        attacker.SetupGet(x => x.OwnerV2).Returns(applier.Object);
        var blocker = Mock.Of<ICreature>();
        var targetOfAttack = Mock.Of<IAttackable>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker.Object);
        var effect = new StealthEffect(Civilization.Light)
        {
            Ability = ability.Object,
            Applier = applier.Object
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.CannotBeBlocked(attacker.Object, blocker, targetOfAttack, battleZone);

        // Assert
        Assert.Equal(hasAnyCivilizationCard, actual);
    }
}