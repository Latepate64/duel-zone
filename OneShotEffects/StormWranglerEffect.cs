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

    public StormWranglerEffect(ICardFilter filter)
    {
        this.filter = filter;
    }

    public StormWranglerEffect(StormWranglerEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
        var creature = Controller.ChooseCardOptionally(
            creatures, ToString()) as ICreature;
        if (creature != null)
        {
            game.AddContinuousEffects(
                Ability, new StormWranglerContinuousEffect(creature));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new StormWranglerEffect(this);
    }
}
