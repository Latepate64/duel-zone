using Engine;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public abstract class ShieldAdditionEffect : CardSelectionEffect<ICard>
{
    protected ShieldAdditionEffect(ShieldAdditionEffect effect) : base(effect)
    {
    }

    protected ShieldAdditionEffect(int minimum, int maximum, bool controllerChooses) : base(
        minimum, maximum, controllerChooses)
    {
    }

    protected override void Apply(IGame game, IAbility source, params ICard[] cards)
    {
        game.Move(Ability, ZoneType.Hand, ZoneType.ShieldZone, cards);
    }
}
