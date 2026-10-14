using Interfaces;
using Moq;
using OneShotEffects;

namespace TestOneShotEffects;

public class TapAllCreaturesEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new TapAllCreaturesEffect(
            filter.Object,
            selectionRange: SelectionRange.OpponentsCards);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEffects()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new TapAllCreaturesEffect(
            filter.Object,
            selectionRange: SelectionRange.OpponentsCards);
        var copy = effect.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = effect.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TapsAllCreatures()
    {
        // Arrange
        const SelectionRange selectionRange = SelectionRange.AllCards;
        var filter = Mock.Of<ICardFilter>();
        var controller = new Mock<IPlayer>();
        ICreature[] creatures = [Mock.Of<ICreature>()];
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(controller.Object);
        var applier = Mock.Of<IPlayerV2>();
        var effect = new TapAllCreaturesEffect(
            filter,
            selectionRange)
        {
            Ability = ability.Object,
            Applier = applier
        };
        var game = new Mock<IGame>();
        game.Setup(x => x.BattleZone.GetCreatures(
            applier, filter, selectionRange)).Returns(creatures);

        // Act
        effect.Apply(game.Object);

        // Assert
        controller.Verify(x => x.Tap(
            game.Object, creatures.OfType<ICard>().ToArray()));
    }
}