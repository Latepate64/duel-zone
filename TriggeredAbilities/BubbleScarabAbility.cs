using Interfaces;
using Interfaces.ContinuousEffects;

namespace TriggeredAbilities;

/// <summary>
/// Whenever one of your creatures is attacked, you may discard a card from your
/// hand. If you do, that creature gets +x power until the end of the turn.
/// </summary>
public sealed class BubbleScarabAbility : LinkedTriggeredAbility
{
    private readonly ICreature? attackTarget;
    private readonly int power;
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;

    public BubbleScarabAbility(
        int power, IContinuousEffectWithCreaturesAndIntegerFactory factory)
    {
        this.power = power;
        this.factory = factory;
    }

    public BubbleScarabAbility(BubbleScarabAbility ability) : base(ability)
    {
        attackTarget = ability.attackTarget;
        power = ability.power;
        factory = ability.factory;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new BubbleScarabAbility(this);
    }

    public override void Resolve(IGame game)
    {
        var card = Controller.ChooseCardOptionally(
            Controller.Hand.Cards, ToString());
        if (card != null)
        {
            Controller.Discard(this, game, card);
            if (attackTarget is not null)
            {
                game.AddContinuousEffects(
                    this,
                    factory.Create(power, attackTarget));
            }
        }
    }

    public override ITriggeredAbility Trigger(
        Guid source, Guid owner, IGameEvent gameEvent)
    {
        throw new NotImplementedException();
    }
}
