using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose one of your creatures in the battle zone. Untap it after the battle.
/// </summary>
public sealed class IkazTheSpydroidEffect : CreatureSelectionEffect
{
    private readonly IDelayedTriggeredAbilityWithEffectAndSourceFactory factory;

    public IkazTheSpydroidEffect(
        IDelayedTriggeredAbilityWithEffectAndSourceFactory factory) : base(1, 1, true)
    {
        this.factory = factory;
    }

    public IkazTheSpydroidEffect(IkazTheSpydroidEffect effect) : base(effect)
    {
        factory = effect.factory;
    }

    public override IOneShotEffect Copy()
    {
        return new IkazTheSpydroidEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddDelayedTriggeredAbility(
            factory.Create(new UntapReferencedCreatureEffect(cards.Single()),
            Ability)
        );
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
