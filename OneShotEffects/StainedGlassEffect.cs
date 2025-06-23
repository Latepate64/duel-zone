using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class StainedGlassEffect : BounceEffect
{
    public StainedGlassEffect() : base(0, 1)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new StainedGlassEffect();
    }

    public override string ToString()
    {
        return "You may choose one of your opponent's fire or nature creatures in the battle zone and return it to its owner's hand.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(
            x => x.HasCivilization(Civilization.Fire, Civilization.Nature));
    }
}
