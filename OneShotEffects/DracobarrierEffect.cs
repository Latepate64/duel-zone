using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class DracobarrierEffect : OneShotEffect
{
    public DracobarrierEffect()
    {
    }

    public DracobarrierEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var controller = Controller;
        var tapped = controller.ChooseOpponentsCreature(game, ToString());
        if (tapped != null)
        {
            controller.Tap(game, tapped);
            if (tapped.IsDragon)
            {
                controller.PutFromTopOfDeckIntoShieldZone(1, game, Ability);
            }
        }
    }

    public override IOneShotEffect Copy()
    {
        return new DracobarrierEffect(this);
    }

    public override string ToString()
    {
        return "Choose one of your opponent's creatures in the battle zone and tap it. If it has Dragon in its race, add the top card of your deck to your shields face down.";
    }
}
