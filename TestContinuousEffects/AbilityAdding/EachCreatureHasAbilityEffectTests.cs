using ContinuousEffects.AbilityAdding;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AbilityAdding;

public class EachCreatureHasAbilityEffectTests
{
    private static EachCreatureHasAbilitiesEffect CreateEffect(ICardFilter filter, IAbility ability)
    {
        return new EachCreatureHasAbilitiesEffectFactory().Create(filter, ability);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var ability = new Mock<IAbility>();
        ability.Setup(x => x.Copy()).Returns(ability.Object);
        var effect = CreateEffect(filter.Object, ability.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void AddsAbility()
    {
        // Arrange
        var filter = Mock.Of<ICardFilter>();
        var ability = Mock.Of<IAbility>();
        var effect = CreateEffect(filter, ability);
        var creature = new Mock<ICreature>();
        var game = new Mock<IGame>();
        game.Setup(x => x.BattleZone.GetCreatures(filter)).Returns([creature.Object]);

        // Act
        effect.AddAbility(game.Object);

        // Assert
        creature.Verify(x => x.AddGrantedAbility(ability));
    }
}