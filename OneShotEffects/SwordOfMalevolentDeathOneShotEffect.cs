using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Until the end of the turn, each of your creatures in the battle zone gets
/// "While attacking, this creature gets +x power for each card in your mana
/// zone."
/// </summary>
public sealed class SwordOfMalevolentDeathOneShotEffect : OneShotEffect
{
    private readonly ICardFilter creatureFilter;
    private readonly int power;
    private readonly ICardFilter manaFilter;
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;
    private readonly IDuration duration;

    public SwordOfMalevolentDeathOneShotEffect(
        ICardFilter creatureFilter,
        int power,
        ICardFilter manaFilter,
        IContinuousEffectWithCreaturesAndIntegerFactory factory,
        IDuration duration)
    {
        this.creatureFilter = creatureFilter;
        this.power = power;
        this.manaFilter = manaFilter;
        this.factory = factory;
        this.duration = duration;
    }

    public SwordOfMalevolentDeathOneShotEffect(
        SwordOfMalevolentDeathOneShotEffect effect) : base(effect)
    {
        creatureFilter = effect.creatureFilter.Copy();
        power = effect.power;
        manaFilter = effect.manaFilter.Copy();
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(
            Applier, creatureFilter);
        var multiplier = Applier.ManaZone.GetNumberOfCards(manaFilter);
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(multiplier * power, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new SwordOfMalevolentDeathOneShotEffect(this);
    }
}
