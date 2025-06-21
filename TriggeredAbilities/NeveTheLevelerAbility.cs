using Engine;
using Engine.Abilities;

namespace TriggeredAbilities;

public class NeveTheLevelerAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
{
    public NeveTheLevelerAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public NeveTheLevelerAbility(NeveTheLevelerAbility ability) : base(ability)
    {
    }

    public override bool CheckInterveningIfClause(IGame game)
    {
        return game.GetBattleZoneCreatures(GetOpponent(game)).Count() > game.GetBattleZoneCreatures(Controller).Count();
    }

    public override IAbility Copy()
    {
        return new NeveTheLevelerAbility(this);
    }

    public override string ToString()
    {
        return $"When you put this creature into the battle zone, if your opponent has more creatures in the battle zone than you do, {GetEffectText()}";
    }
}
