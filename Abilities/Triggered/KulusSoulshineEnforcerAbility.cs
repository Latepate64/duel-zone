using Engine;
using Engine.Abilities;

namespace Abilities.Triggered;

public class KulusSoulshineEnforcerAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
{
    public KulusSoulshineEnforcerAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public KulusSoulshineEnforcerAbility(KulusSoulshineEnforcerAbility ability) : base(ability)
    {
    }

    public override bool CheckInterveningIfClause(IGame game)
    {
        return GetOpponent(game).ManaZone.Size > Controller.ManaZone.Size;
    }

    public override IAbility Copy()
    {
        return new KulusSoulshineEnforcerAbility(this);
    }

    public override string ToString()
    {
        return $"When you put this creature into the battle zone, if your opponent has more cards in his mana zone than you have in yours, {OneShotEffect}";
    }
}
