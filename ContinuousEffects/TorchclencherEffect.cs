using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class TorchclencherEffect : ContinuousEffect, IAbilityAddingEffect
{
    public TorchclencherEffect()
    {
    }

    public TorchclencherEffect(TorchclencherEffect effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        var creature = Source;
        if (game.BattleZone.GetOtherCreatureCount(Controller.Id, creature.Id, Civilization.Fire) > 0)
        {
            creature.AddGrantedAbility(new StaticAbility(new PowerAttackerEffect(3000)));
        }
    }

    public override IContinuousEffect Copy()
    {
        return new TorchclencherEffect(this);
    }

    public override string ToString()
    {
        return "While you have at least one other fire creature in the battle zone, this creature has \"Power attacker +3000.\"";
    }
}
