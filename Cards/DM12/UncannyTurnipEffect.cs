using Engine.Abilities;
using Interfaces;

namespace Cards.DM12;

public class UncannyTurnipEffect : OneShotEffect
{
    public UncannyTurnipEffect()
    {
    }

    public UncannyTurnipEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var controller = Controller;
        controller.PutFromTopOfDeckIntoManaZone(game, 1, Ability);
        controller.ReturnOwnManaCreature(game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new UncannyTurnipEffect(this);
    }

    public override string ToString()
    {
        return "Put the top card of your deck into your mana zone. Then put a creature from your mana zone into your hand.";
    }
}
