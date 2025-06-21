using Engine;
using Engine.ContinuousEffects;
using Interfaces;

namespace ContinuousEffects;

public class NotDestroyedInBattleEffect : ContinuousEffect, INotDestroyedInBattleEffect, ICivilizationable
{
    public NotDestroyedInBattleEffect(Civilization civilization) : base()
    {
        Civilization = civilization;
    }

    public NotDestroyedInBattleEffect(NotDestroyedInBattleEffect effect) : base(effect)
    {
        Civilization = effect.Civilization;
    }

    public Civilization Civilization { get; }

    public bool Applies(Card against, Creature creature, IGame game)
    {
        return IsSourceOfAbility(creature) && against.HasCivilization(Civilization);
    }

    public override IContinuousEffect Copy()
    {
        return new NotDestroyedInBattleEffect(this);
    }

    public override string ToString()
    {
        return $"When this creature loses a battle against a {Civilization.ToString().ToLower()} creature, this creature isn't destroyed.";
    }
}
