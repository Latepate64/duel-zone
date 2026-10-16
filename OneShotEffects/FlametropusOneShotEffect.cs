using Interfaces;

namespace OneShotEffects;

/// <summary>
/// You may put a card from your mana zone into your graveyard. If you do, this
/// creature gets "power attacker +3000" and "double breaker" until the end of
/// the turn.
/// </summary>
public sealed class FlametropusOneShotEffect : OneShotEffect
{
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;

    public FlametropusOneShotEffect(
        IContinuousEffectWithCreaturesAndIntegerFactory factory)
    {
        this.factory = factory;
    }

    public FlametropusOneShotEffect(
        FlametropusOneShotEffect effect) : base(effect)
    {
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        var card = player.ChooseCardOptionally(player.ManaZone.Cards, ToString());
        if (card != null)
        {
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, card);
            game.AddContinuousEffects(
                Ability,
                factory.Create(3000, (ICreature)Ability.Source));                 
        }
    }

    public override IOneShotEffect Copy()
    {
        return new FlametropusOneShotEffect(this);
    }
}
