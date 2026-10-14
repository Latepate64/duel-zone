using Interfaces;
using Moq;
using OneShotEffects;

namespace TestOneShotEffects;

public class MutualManaSacrificeEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new MutualManaSacrificeEffect(1);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEffects()
    {
        // Arrange
        var effect = new MutualManaSacrificeEffect(1);
        var copy = effect.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = effect.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void BothPlayersSacrificeMana(int amount)
    {
        // Arrange
        ICard[] ownMana = [Mock.Of<ICard>(), Mock.Of<ICard>()];
        ICard[] opponentsMana = [Mock.Of<ICard>(), Mock.Of<ICard>()];
        var controller = new Mock<IPlayer>();
        controller.SetupGet(x => x.ManaZone.Cards).Returns(ownMana);
        controller.Setup(x => x.ChooseCards(
            ownMana, amount, amount, It.IsAny<string>())).Returns(
                ownMana.Take(amount));
        var opponent = new Mock<IPlayer>();
        opponent.SetupGet(x => x.ManaZone.Cards).Returns(opponentsMana);
        opponent.Setup(x => x.ChooseCards(
            opponentsMana, amount, amount, It.IsAny<string>())).Returns(
                opponentsMana.Take(amount));
        var source = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(source);
        ability.SetupGet(x => x.Controller).Returns(controller.Object);
        var effect = new MutualManaSacrificeEffect(amount)
        {
            Ability = ability.Object,
        };
        var game = new Mock<IGame>();
        game.SetupGet(x => x.Players).Returns(
            [controller.Object, opponent.Object]);

        // Act
        effect.Apply(game.Object);

        // Assert
        game.Verify(x => x.Move(
            ability.Object,
            ZoneType.ManaZone,
            ZoneType.Graveyard,
            ownMana.Take(amount).Union(opponentsMana.Take(amount)).ToArray()));
    }
}