using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class TropicCrawlerEffect : CardMovingChoiceEffect<ICreature>
{
    public TropicCrawlerEffect() : base(1, 1, false, ZoneType.BattleZone, ZoneType.Hand)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new TropicCrawlerEffect();
    }

    public override string ToString()
    {
        return "Your opponent chooses one of his creatures in the battle zone, and returns it to his hand.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(GetOpponent(game).Id);
    }
}
