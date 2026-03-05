using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class CivilizationSlayerEffect : ContinuousEffect, ISlayerEffect, IMultiCivilizationable
{
    public CivilizationSlayerEffect(params Civilization[] civilizations) : base()
    {
        Civilizations = civilizations;
    }

    public CivilizationSlayerEffect(CivilizationSlayerEffect effect) : base(effect)
    {
        Civilizations = effect.Civilizations;
    }

    public Civilization[] Civilizations { get; }

    public bool Applies(ICreature creature, ICard against, IGame game)
    {
        return IsSourceOfAbility(creature) && against.Civilizations.Intersect(Civilizations).Any();
    }

    public override IContinuousEffect Copy()
    {
        return new CivilizationSlayerEffect(this);
    }

    public override string ToString()
    {
        return $"{string.Join(" and ", Civilizations.Select(x => x.ToString().ToLower()))} slayer";
    }
}
