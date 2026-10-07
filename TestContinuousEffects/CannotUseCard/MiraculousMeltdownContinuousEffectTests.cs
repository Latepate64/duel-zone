using ContinuousEffects.CannotUseCard;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CannotUseCard;

public class MiraculousMeltdownContinuousEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new MiraculousMeltdownContinuousEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void DoesNotApplyToOtherCards()
    {
        // Arrange
        var effect = new MiraculousMeltdownContinuousEffect();

        // Act
        var actual = effect.Applies(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void AppliesBasedOnWhetherApplierHasLessShieldsThanTheirOpponent(
        bool applierHasLessShields)
    {
        // Arrange
        var spell = Mock.Of<ISpell>();
        var spellAbility = new Mock<ISpellAbility>();
        spellAbility.SetupGet(x => x.Source).Returns(spell);
        var applier = new Mock<IPlayerV2>();
        applier.SetupGet(x => x.ShieldZone.Size).Returns(
            applierHasLessShields ? 0 : 2);
        var opponent = new Mock<IPlayerV2>();
        opponent.SetupGet(x => x.ShieldZone.Size).Returns(1);
        applier.SetupGet(x => x.Opponent).Returns(opponent.Object);
        var effect = new MiraculousMeltdownContinuousEffect
        {
            Ability = spellAbility.Object,
            Applier = applier.Object
        };

        // Act
        var actual = effect.Applies(spell);

        // Assert
        Assert.Equal(!applierHasLessShields, actual);
    }
}