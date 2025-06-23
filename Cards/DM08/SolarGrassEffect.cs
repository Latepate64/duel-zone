using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Cards.DM08;

public sealed class SolarGrassEffect : UntapAreaOfEffect
{
    public SolarGrassEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new SolarGrassEffect();
    }

    public override string ToString()
    {
        return "Untap all your creatures in the battle zone except Solar Grasses.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id).Where(x => x.Name != "Solar Grass");
    }
}
