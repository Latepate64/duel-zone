using Abilities;
using ContinuousEffects.Breaker;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public sealed class KilstineNebulaElementalEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
{
    public KilstineNebulaElementalEffect() : base()
    {
    }

    public void AddAbility(IGame game)
    {
        GetAffectedCards(game).ForEach(x => { 
            x.AddGrantedAbility(new BlockerAbility());
            x.AddGrantedAbility(new StaticAbility(new DoubleBreakerEffect()));
            });
    }

    public override IContinuousEffect Copy()
    {
        return new KilstineNebulaElementalEffect();
    }

    public void ModifyPower(IGame game)
    {
        GetAffectedCards(game).ForEach(x => x.IncreasePower(5000));
    }

    public override string ToString()
    {
        return "Each of your other creatures in battle zone gets +5000 power and has \"blocker\" and \"double breaker\".";
    }

    private List<ICreature> GetAffectedCards(IGame game)
    {
        return [.. game.BattleZone.GetCreatures(Controller.Id).Where(x => !IsSourceOfAbility(x))];
    }
}
