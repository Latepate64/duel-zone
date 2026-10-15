using Interfaces;
using Moq;
using OneShotEffects;

namespace TestOneShotEffects;

public class UntapAreaOfEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new UntapAreaOfEffect(
            Mock.Of<ICardFilter>(), SelectionRange.OwnCards
        );

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEffects()
    {
        // Arrange
        var effect = new UntapAreaOfEffect(
            Mock.Of<ICardFilter>(), SelectionRange.OwnCards
        );
        var copy = effect.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = effect.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CreaturesGetUntapped()
    {
        // Arrange
        const SelectionRange selectionRange = SelectionRange.OwnCards;
        var controller = new Mock<IPlayer>();
        var game = new Mock<IGame>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(controller.Object);
        var applier = Mock.Of<IPlayerV2>();
        var filter = Mock.Of<ICardFilter>();
        var effect = new UntapAreaOfEffect(filter, selectionRange)
        {
            Ability = ability.Object,
            Applier = applier
        };
        ICreature[] creatures = [Mock.Of<ICreature>()];
        game.Setup(x => x.BattleZone.GetCreatures(
            applier, filter, selectionRange)).Returns(creatures);

        // Act
        effect.Apply(game.Object);

        // Assert
        controller.Verify(x => x.Untap(game.Object, creatures));
    }
}
