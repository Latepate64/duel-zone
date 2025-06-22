using Engine.Abilities;
using Interfaces;

namespace Cards.DM09;

public sealed class ManaBonanzaEffect : OneShotEffect
{
    public ManaBonanzaEffect()
    {
    }

    public ManaBonanzaEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        Controller.PutFromTopOfDeckIntoManaZone(game, Controller.ManaZone.Size, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new ManaBonanzaEffect(this);
    }

    public override string ToString()
    {
        return "For each card in your mana zone, put a card from the top of your deck into your mana zone tapped.";
    }
}
