using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM08;

sealed class MagmadragonJagalzorEffect : ContinuousEffect, ISpeedAttackerEffect
{
    public MagmadragonJagalzorEffect() : base()
    {
    }

    public bool Applies(ICreature creature, IGame game)
    {
        return creature.Owner == Controller;
    }

    public override IContinuousEffect Copy()
    {
        return new MagmadragonJagalzorEffect();
    }

    public override string ToString()
    {
        return "Each of your creatures in the battle zone has \"speed attacker.\"";
    }
}
