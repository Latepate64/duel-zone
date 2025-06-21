using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class CivilizationBlockerEffect : ContinuousEffect, IBlockerEffect, IMultiCivilizationable
{
    public CivilizationBlockerEffect(params Civilization[] civilizations) : base()
    {
        Civilizations = civilizations;
    }

    public CivilizationBlockerEffect(CivilizationBlockerEffect effect) : base(effect)
    {
        Civilizations = effect.Civilizations;
    }

    public Civilization[] Civilizations { get; }

    public bool CanBlock(ICreature blocker, ICreature attacker, IGame game)
    {
        return IsSourceOfAbility(blocker) && attacker.Civilizations.Intersect(Civilizations).Any();
    }

    public override IContinuousEffect Copy()
    {
        return new CivilizationBlockerEffect(this);
    }

    public override string ToString()
    {
        return $"{string.Join(" and ", Civilizations.Select(x => x.ToString().ToLower()))} blocker";
    }
}
