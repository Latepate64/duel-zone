using Interfaces;

namespace OneShotEffects;

public sealed class ThornyMandraEffect : FromGraveyardIntoManaZoneEffect
{
    public ThornyMandraEffect() : base(0, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ThornyMandraEffect();
    }

    public override string ToString()
    {
        return "You may put a creature from your graveyard into your mana zone.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.Creatures;
    }
}
