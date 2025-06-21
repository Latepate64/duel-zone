using Engine;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public class TraRionPenumbraGuardianUntapEffect : UntapAreaOfEffect, IRaceable
{
    public TraRionPenumbraGuardianUntapEffect(Race race) : base()
    {
        Race = race;
    }

    public TraRionPenumbraGuardianUntapEffect(TraRionPenumbraGuardianUntapEffect effect) : base(effect)
    {
        Race = effect.Race;
    }

    public Race Race { get; }

    public override IOneShotEffect Copy()
    {
        return new TraRionPenumbraGuardianUntapEffect(this);
    }

    public override string ToString()
    {
        return $"Untap all {Race}s in the battle zone.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Race);
    }
}
