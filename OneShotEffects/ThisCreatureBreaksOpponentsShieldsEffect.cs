using Interfaces;

namespace OneShotEffects;

public abstract class ThisCreatureBreaksOpponentsShieldsEffect : BreaksOpponentsShieldsEffect
{
    protected ThisCreatureBreaksOpponentsShieldsEffect(ThisCreatureBreaksOpponentsShieldsEffect effect) : base(effect)
    {
    }

    protected ThisCreatureBreaksOpponentsShieldsEffect(int amount) : base(amount)
    {
    }

    public override string ToString()
    {
        return $"This creature breaks {_amount} of your opponent's shields.";
    }

    protected override ICreature GetBreaker(IGame game, IAbility source)
    {
        return Ability.Source as ICreature;
    }
}
