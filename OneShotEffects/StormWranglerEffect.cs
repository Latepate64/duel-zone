using Interfaces;
using ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// You may choose one of your opponent's creatures. This turn, that creature
/// blocks this creature if able and this creature can't be blocked by other
/// creatures.
/// </summary>
public sealed class StormWranglerEffect : OneShotEffect
{
    private readonly ICardFilter filter;
    private readonly IContinuousEffectFactory factory;

    public StormWranglerEffect(
        ICardFilter filter, IContinuousEffectFactory factory)
    {
        this.filter = filter;
        this.factory = factory;
    }

    public StormWranglerEffect(StormWranglerEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
        if (Controller.ChooseCardOptionally(
            creatures, ToString()) is ICreature creature)
        {
            game.AddContinuousEffects(
                Ability,
                factory.Create(creature));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new StormWranglerEffect(this);
    }
}
