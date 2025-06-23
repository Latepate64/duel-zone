using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;
using OneShotEffects;

namespace OneShotEffects;

public sealed class DeathCruzerTheAnnihilatorEffect : DestroyAreaOfEffect
{
    public DeathCruzerTheAnnihilatorEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DeathCruzerTheAnnihilatorEffect();
    }

    public override string ToString()
    {
        return "Destroy all your other creatures.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetOtherCreatures(Ability.Controller.Id, Ability.Source.Id);
    }
}
