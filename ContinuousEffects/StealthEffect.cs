using Engine;
using Engine.ContinuousEffects;
using Interfaces;

namespace ContinuousEffects;

public class StealthEffect : ContinuousEffect, IUnblockableEffect, ICivilizationable
{
    public StealthEffect(Civilization civilization) : base()
    {
        Civilization = civilization;
    }

    public StealthEffect(StealthEffect effect) : base(effect)
    {
        Civilization = effect.Civilization;
    }

    public Civilization Civilization { get; }

    public bool CannotBeBlocked(Creature attacker, Creature blocker, IAttackable targetOfAttack, IGame game)
    {
        return attacker == Source && GetOpponent(game).ManaZone.Cards.Any(x => x.HasCivilization(Civilization));
    }

    public override IContinuousEffect Copy()
    {
        return new StealthEffect(this);
    }

    public override string ToString()
    {
        return $"{Civilization} stealth";
    }
}
