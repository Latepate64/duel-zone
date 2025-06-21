using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures : PowerModifyingMultiplierEffect
{
    public ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures effect) : base(effect)
    {
    }

    public ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(int power) : base(power)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(this);
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each of your other untapped creatures in the battle zone.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetOtherUntappedCreatures(Controller.Id, Source.Id).Count();
    }
}
