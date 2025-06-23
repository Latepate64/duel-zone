using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;

namespace ContinuousEffects;

public sealed class GregoriaPrincessOfWarEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
{
    public GregoriaPrincessOfWarEffect() : base() { }

    public GregoriaPrincessOfWarEffect(GregoriaPrincessOfWarEffect effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        GetAffectedCards(game).ForEach(x => x.AddGrantedAbility(new StaticAbility(
            new ThisCreatureHasBlockerEffect())));
    }

    public override IContinuousEffect Copy()
    {
        return new GregoriaPrincessOfWarEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        GetAffectedCards(game).ForEach(x => x.IncreasePower(2000));
    }

    public override string ToString()
    {
        return "Each Demon Command in the battle zone gets +2000 power and has \"blocker.\"";
    }

    private static List<ICreature> GetAffectedCards(IGame game)
    {
        return [.. game.BattleZone.GetCreatures(Race.DemonCommand)];
    }
}
