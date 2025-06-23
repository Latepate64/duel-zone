using Interfaces;

namespace OneShotEffects;

public sealed class DivineRiptideEffect : ManaRecoveryAreaOfEffect
{
    public DivineRiptideEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DivineRiptideEffect();
    }

    public override string ToString()
    {
        return "Each player returns all cards from his mana zone to his hand.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.Players.SelectMany(x => x.ManaZone.Cards);
    }
}
