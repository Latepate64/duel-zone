using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class ThisCreatureGetsTwoAbilitiesIfYouSacrificeManaEffect : OneShotEffect
{
    private readonly IThisCreatureGetsTwoAbilitiesEffectFactory factory;
    private readonly IStaticAbilityWithIntegerFactory abilityWithIntegerFactory;
    private readonly IStaticAbilityFactory abilityFactory;
    private readonly int power;

    public ThisCreatureGetsTwoAbilitiesIfYouSacrificeManaEffect(
        IThisCreatureGetsTwoAbilitiesEffectFactory factory,
        IStaticAbilityWithIntegerFactory abilityWithIntegerFactory, 
        IStaticAbilityFactory abilityFactory,
        int power)
    {
        this.factory = factory;
        this.abilityWithIntegerFactory = abilityWithIntegerFactory;
        this.abilityFactory = abilityFactory;
        this.power = power;
    }

    public ThisCreatureGetsTwoAbilitiesIfYouSacrificeManaEffect(
        ThisCreatureGetsTwoAbilitiesIfYouSacrificeManaEffect effect) : base(effect)
    {
        factory = effect.factory;
        abilityWithIntegerFactory = effect.abilityWithIntegerFactory;
        abilityFactory = effect.abilityFactory;
        power = effect.power;
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
                factory.Create(
                    power,
                    abilityWithIntegerFactory,
                    abilityFactory,
                    (ICreature)Ability.Source));                 
        }
    }

    public override IOneShotEffect Copy()
    {
        return new ThisCreatureGetsTwoAbilitiesIfYouSacrificeManaEffect(this);
    }
}
