using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class SirenConcertoEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var controller = Controller;
        controller.ReturnOwnMana(game, Ability);
        controller.PutOwnHandCardIntoMana(game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new SirenConcertoEffect();
    }

    public override string ToString()
    {
        return "Put a card from your mana zone into your hand. Then put a card from your hand into your mana zone.";
    }
}
