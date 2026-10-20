using ContinuousEffects.CannotAttackPlayers;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CannotAttackPlayers;

public class CivilizationCreaturesCannotAttackYouEffectTests
{
    private static CivilizationCreaturesCannotAttackYouEffect CreateEffect(
        Civilization civilization)
    {
        return (CivilizationCreaturesCannotAttackYouEffect)
            new CivilizationCreaturesCannotAttackYouEffectFactory().Create(civilization);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = CreateEffect(Civilization.Light);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void AttackerWithCivilizationCannotAttackPlayers(bool hasCivilization)
    {
        // Arrange
        var attacker = new Mock<ICreature>();
        attacker.Setup(x => x.HasCivilization(Civilization.Light)).Returns(hasCivilization);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker.Object);
        var effect = CreateEffect(Civilization.Light);
        effect.Ability = ability.Object;

        // Act
        var actual = effect.CannotAttackPlayers(attacker.Object, Mock.Of<IGame>());

        // Assert
        Assert.Equal(hasCivilization, actual);
    }
}