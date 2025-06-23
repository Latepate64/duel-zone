using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class GandarSeekerOfExplosionsUntapEffect : UntapAreaOfEffect
{
    public GandarSeekerOfExplosionsUntapEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new GandarSeekerOfExplosionsUntapEffect();
    }

    public override string ToString()
    {
        return "Untap all your light creatures.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id, Civilization.Light);
    }
}
