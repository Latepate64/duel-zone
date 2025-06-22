using TriggeredAbilities;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM11;

public class SlashAndBurnEffect : OneShotEffect
{
    public SlashAndBurnEffect()
    {
    }

    public SlashAndBurnEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(new WheneverSomethingHappensThisTurnAbility(
            new SlashAndBurnAbility(), Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new SlashAndBurnEffect(this);
    }

    public override string ToString()
    {
        return "Whenever any of your opponent's creatures is destroyed this turn, your opponent chooses a card in his mana zone and puts it into his graveyard. Then he chooses one of his shields and puts it into his graveyard.";
    }
}
