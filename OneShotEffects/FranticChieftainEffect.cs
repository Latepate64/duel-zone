using Interfaces;

namespace OneShotEffects;

public sealed class FranticChieftainEffect : BounceEffect
{
    public FranticChieftainEffect() : base(1, 1)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new FranticChieftainEffect();
    }

    public override string ToString()
    {
        return "Return one of your creatures that costs 4 or less from the battle zone to your hand.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id).Where(x => x.ManaCost <= 4);
    }
}
