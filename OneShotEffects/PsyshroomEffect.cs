using Interfaces;

namespace OneShotEffects;

public sealed class PsyshroomEffect : FromGraveyardIntoManaZoneEffect
{
    public PsyshroomEffect() : base(0, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new PsyshroomEffect();
    }

    public override string ToString()
    {
        return "You may put a nature card from your graveyard into your mana zone.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.GetCards(Civilization.Nature);
    }
}
