using Interfaces;

namespace OneShotEffects;

public sealed class SchukaDukeOfAmnesiaEffect : OneShotEffects.CardMovingAreaOfEffect
{
    public SchukaDukeOfAmnesiaEffect() : base(ZoneType.Hand, ZoneType.Graveyard)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new SchukaDukeOfAmnesiaEffect();
    }

    public override string ToString()
    {
        return "Each player discards his hand.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.Players.SelectMany(x => x.Hand.Cards);
    }
}
