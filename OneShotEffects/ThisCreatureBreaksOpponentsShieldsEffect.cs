using Interfaces;

namespace OneShotEffects;

public sealed class ThisCreatureBreaksOpponentsShieldsEffect : OneShotEffect
{
    private readonly int amount;

    public ThisCreatureBreaksOpponentsShieldsEffect(int amount) : base()
    {
         this.amount = amount;
    }

    private ThisCreatureBreaksOpponentsShieldsEffect(
        ThisCreatureBreaksOpponentsShieldsEffect effect) : base(effect)
    {
        amount = effect.amount;
    }

    public override IOneShotEffect Copy()
    {
        return new ThisCreatureBreaksOpponentsShieldsEffect(this);
    }

    public override void Apply(IGame game)
    {
        game.Break((ICreature)Ability.Source, amount);
    }
}
