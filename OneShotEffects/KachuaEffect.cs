using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Search your deck. You may take a creature that has Dragon in its race from
/// your deck and put it into the battle zone. Then shuffle your deck. That
/// creature has "speed attacker." At the end of the turn, destroy it.
/// </summary>
public sealed class KachuaEffect : OneShotEffect
{
    private readonly IContinuousEffectFactory effectFactory;
    private readonly IKachuaDelayedTriggeredAbilityFactory abilityFactory;

    public KachuaEffect(
        IContinuousEffectFactory effectFactory,
        IKachuaDelayedTriggeredAbilityFactory abilityFactory)
    {
        this.effectFactory = effectFactory;
        this.abilityFactory = abilityFactory;
    }

    public KachuaEffect(KachuaEffect effect) : base(effect)
    {
        effectFactory = effect.effectFactory;
        abilityFactory = effect.abilityFactory;
    }

    public override void Apply(IGame game)
    {
        var cards = Controller.Deck.Creatures.Where(x => x.IsDragon);
        var dragon = Controller.ChooseCardOptionally(cards, ToString()) as ICreature;
        if (dragon != null)
        {
            game.Move(Ability, ZoneType.Deck, ZoneType.Hand, dragon);
        }
        Controller.ShuffleOwnDeck(game);
        if (dragon != null)
        {
            game.AddContinuousEffects(
                Ability,
                effectFactory.Create(dragon));
            game.AddDelayedTriggeredAbility(
                abilityFactory.Create(Ability, Guid.NewGuid(), dragon));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new KachuaEffect(this);
    }
}
