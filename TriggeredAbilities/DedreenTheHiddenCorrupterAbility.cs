using Engine;
using Engine.Abilities;

namespace TriggeredAbilities;

public class DedreenTheHiddenCorrupterAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
{
    private readonly int _shieldsMaximum;

    public DedreenTheHiddenCorrupterAbility(int shieldsMaximum, IOneShotEffect effect) : base(effect)
    {
        _shieldsMaximum = shieldsMaximum;
    }

    public DedreenTheHiddenCorrupterAbility(DedreenTheHiddenCorrupterAbility ability) : base(ability)
    {
        _shieldsMaximum = ability._shieldsMaximum;
    }

    public override IAbility Copy()
    {
        return new DedreenTheHiddenCorrupterAbility(this);
    }

    public override bool CheckInterveningIfClause(IGame game)
    {
        return GetOpponent(game).ShieldZone.Size <= _shieldsMaximum;
    }

    public override string ToString()
    {
        return $"When you put this creature into the battle zone, if your opponent has {_shieldsMaximum} or fewer shields, {GetEffectText()}";
    }
}
