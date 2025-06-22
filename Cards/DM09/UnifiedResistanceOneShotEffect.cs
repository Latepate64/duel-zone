using Engine.Abilities;
using Interfaces;
using System.Linq;

namespace Cards.DM09;

public sealed class UnifiedResistanceOneShotEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id).Where(x => x.HasRace(race));
        game.AddContinuousEffects(Ability, new UnifiedResistanceContinuousEffect(
            Ability.Controller.Id, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new UnifiedResistanceOneShotEffect();
    }

    public override string ToString()
    {
        return "Choose a race. Until the start of your next turn, each of your creatures in the battle zone of that race gets \"Blocker.\"";
    }
}
