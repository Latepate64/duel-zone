using Interfaces;

namespace OneShotEffects;

public sealed class ScreamingSunburstEffect : TapAreaOfEffect
{
    public ScreamingSunburstEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ScreamingSunburstEffect();
    }

    public override string ToString()
    {
        return "Tap all creatures in the battle zone except light creatures.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.Creatures.Where(x => !x.HasCivilization(Civilization.Light));
    }
}
