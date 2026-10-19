using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Search your deck. You may take a creature that has Dragon in its race from
/// your deck and put it into the battle zone. Then shuffle your deck. That
/// creature has "speed attacker." At the end of the turn, destroy it.
/// </summary>
public sealed class KachuaEffect : OneShotEffect
{
    private readonly IAbilityAddingContinuousEffectFactory effectFactory;
    private readonly IDelayedTriggeredAbilityWithTurnAndCreaturesFactory abilityFactory;
    private readonly IAbility ability;

    internal KachuaEffect(
        IAbilityAddingContinuousEffectFactory effectFactory,
        IDelayedTriggeredAbilityWithTurnAndCreaturesFactory abilityFactory,
        IAbility ability)
    {
        this.effectFactory = effectFactory;
        this.abilityFactory = abilityFactory;
        this.ability = ability;
    }

    private KachuaEffect(KachuaEffect effect) : base(effect)
    {
        effectFactory = effect.effectFactory;
        abilityFactory = effect.abilityFactory;
        ability = effect.ability;
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
                effectFactory.Create(ability, dragon));
            game.AddDelayedTriggeredAbility(
                abilityFactory.Create(Ability, Guid.NewGuid(), dragon));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new KachuaEffect(this);
    }
}
