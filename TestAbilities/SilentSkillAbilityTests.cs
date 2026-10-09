using Abilities;
using Interfaces;
using Moq;

namespace TestAbilities;

public class SilentSkillAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new Mock<IOneShotEffect>();
        effect.Setup(x => x.Copy()).Returns(effect.Object);
        var ability = new SilentSkillAbility(effect.Object);

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }
}