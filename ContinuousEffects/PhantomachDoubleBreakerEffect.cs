using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class PhantomachDoubleBreakerEffect : AbilityAddingEffect
{
    public PhantomachDoubleBreakerEffect() : base(new StaticAbility(new DoubleBreakerEffect()))
    {
    }

    public override IContinuousEffect Copy()
    {
        return new PhantomachDoubleBreakerEffect();
    }

    public override string ToString()
    {
        return "Each of your Chimeras and Armorloids in the battle zone has \"double breaker.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id, Race.Chimera, Race.Armorloid);
    }
}
