using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM07;

public sealed class GandarSeekerOfExplosionsUntapEffect : UntapAreaOfEffect
{
    public GandarSeekerOfExplosionsUntapEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new GandarSeekerOfExplosionsUntapEffect();
    }

    public override string ToString()
    {
        return "Untap all your light creatures.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id, Civilization.Light);
    }
}
