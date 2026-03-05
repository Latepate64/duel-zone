using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class QTronicOmnistrainEffect : ContinuousEffect, IRaceAddingEffect
{
    public void AddRace(IGame game)
    {
        game.BattleZone.GetCreatures(Controller.Id).ToList().ForEach(x => x.AddGrantedRace(Race.Survivor));
    }

    public override IContinuousEffect Copy()
    {
        return new QTronicOmnistrainEffect();
    }

    public override string ToString()
    {
        return "Each of your creatures in the battle zone is a Survivor in addition to its other races.";
    }
}
