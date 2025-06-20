using Engine;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class ThisCreatureCanAttackUntappedCivilizationCreaturesEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect, ICivilizationable
{
    public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(ThisCreatureCanAttackUntappedCivilizationCreaturesEffect effect) : base(effect)
    {
        Civilization = effect.Civilization;
    }

    public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Civilization civilization) : base()
    {
        Civilization = civilization;
    }

    public Civilization Civilization { get; }

    public bool CanAttackUntappedCreature(Creature attacker, Creature targetOfAttack, IGame game)
    {
        return IsSourceOfAbility(attacker) && targetOfAttack.HasCivilization(Civilization);
    }

    public override ContinuousEffect Copy()
    {
        return new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(this);
    }

    public override string ToString()
    {
        return $"This creature can attack untapped {Civilization.ToString().ToLower()} creatures.";
    }
}
