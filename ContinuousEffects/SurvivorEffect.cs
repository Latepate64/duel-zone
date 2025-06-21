using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class SurvivorEffect : AbilityAddingEffect
{
    public SurvivorEffect(SurvivorEffect effect) : base(effect)
    {
    }

    public SurvivorEffect(IAbility ability) : base(ability)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new SurvivorEffect(this);
    }

    public override string ToString()
    {
        return $"Survivor : {AbilitiesAsText}";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id, Race.Survivor);
    }
}
