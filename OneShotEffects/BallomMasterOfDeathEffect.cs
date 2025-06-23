using Interfaces;

namespace OneShotEffects;

public sealed class BallomMasterOfDeathEffect : DestroyAreaOfEffect
{
    public BallomMasterOfDeathEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new BallomMasterOfDeathEffect();
    }

    public override string ToString()
    {
        return "Destroy all creatures except darkness creatures.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.Creatures.Where(x => !x.HasCivilization(Civilization.Darkness));
    }
}
