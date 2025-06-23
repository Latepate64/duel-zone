using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class SupportingTulipEffect : AbilityAddingEffect
{
    public SupportingTulipEffect(SupportingTulipEffect effect) : base(effect)
    {
    }

    public SupportingTulipEffect() : base(new StaticAbility(new PowerAttackerEffect(4000)))
    {
    }

    public override IContinuousEffect Copy()
    {
        return new SupportingTulipEffect(this);
    }

    public override string ToString()
    {
        return "Each Angel Command in the battle zone has \"power attacker +4000.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreatures(Race.AngelCommand);
    }
}
