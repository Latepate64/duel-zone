using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public class SacrificeEffect : DestroyEffect
{
    public SacrificeEffect() : base(1, 1, true)
    {
    }

    public SacrificeEffect(DestroyEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new SacrificeEffect(this);
    }

    public override string ToString()
    {
        return "Destroy one of your creatures.";
    }

    protected override IEnumerable<Creature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
