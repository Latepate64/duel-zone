using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect : DestroyEffect
{
    public DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect() : base(1, 1, true)
    {
    }

    public DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect(
        DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect(this);
    }

    public override string ToString()
    {
        return "Destroy one of your opponent's creatures that has \"blocker.\"";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(
            game, GetOpponent(game).Id).Where(x => x.GetAbilities<StaticAbility>().SelectMany(
                x => x.ContinuousEffects).OfType<IBlockerEffect>().Any());
    }
}
