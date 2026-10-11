using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;

namespace OneShotEffects;

/// <summary>
/// You may destroy one of your other creatures. If you do, this creature gets
/// +x power and has "double breaker" until the end of the turn.
/// </summary>
public sealed class YouMaySacrificeAnotherCreatureIfYouDoThisCreatureGetsPowerAndDoubleBreakerUntilEndOfTurnEffect
    : OneShotEffect
{
    private readonly int power;
    private readonly ICardFilter filter;

    public YouMaySacrificeAnotherCreatureIfYouDoThisCreatureGetsPowerAndDoubleBreakerUntilEndOfTurnEffect(
        int power, ICardFilter filter)
    {
        this.power = power;
        this.filter = filter;
    }

    public YouMaySacrificeAnotherCreatureIfYouDoThisCreatureGetsPowerAndDoubleBreakerUntilEndOfTurnEffect(
        YouMaySacrificeAnotherCreatureIfYouDoThisCreatureGetsPowerAndDoubleBreakerUntilEndOfTurnEffect effect) : base(effect)
    {
        power = effect.power;
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var source = (ICreature)Source!;
        var creature = Controller.ChooseCardOptionally(
            game.BattleZone.GetOtherCreaturesControlledByPlayer(source, filter),
            ToString());
        if (creature != null)
        {
            game.Destroy(Ability, source);
            game.AddContinuousEffects(
                Ability,
                new ThreeEyedDragonflyContinuousEffect(power, source));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new YouMaySacrificeAnotherCreatureIfYouDoThisCreatureGetsPowerAndDoubleBreakerUntilEndOfTurnEffect(
            this);
    }
}
