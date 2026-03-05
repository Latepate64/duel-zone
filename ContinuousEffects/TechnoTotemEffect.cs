using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class TechnoTotemEffect : ContinuousEffect, IAbilityAddingEffect
{
    public TechnoTotemEffect()
    {
    }

    public TechnoTotemEffect(TechnoTotemEffect effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        if (Source.Tapped)
        {
            game.BattleZone.GetOtherCreatures(Controller.Id, Source.Id).ToList().ForEach(x => x.AddGrantedAbility(
                new StaticAbility(new PowerAttackerEffect(1500))));
        }
    }

    public override IContinuousEffect Copy()
    {
        return new TechnoTotemEffect(this);
    }

    public override string ToString()
    {
        return "While this creature is tapped, each of your other creatures has \"power attacker +1500.\"";
    }
}
