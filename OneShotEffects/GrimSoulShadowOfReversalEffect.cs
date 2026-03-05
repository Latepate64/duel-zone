using Interfaces;

namespace OneShotEffects;

public sealed class GrimSoulShadowOfReversalEffect : SalvageCivilizationCreatureEffect
{
    public GrimSoulShadowOfReversalEffect() : base(1, 1)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new GrimSoulShadowOfReversalEffect();
    }

    public override string ToString()
    {
        return "Return a darkness creature from your graveyard to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.GetCreatures(Civilization.Darkness);
    }
}
