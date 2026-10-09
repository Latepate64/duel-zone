using OneShotEffects;

namespace TestOneShotEffects;

public class PutTopCardOfDeckIntoManaZoneEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new PutTopCardOfDeckIntoManaZoneEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }
}
