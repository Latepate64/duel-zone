using Interfaces;

namespace OneShotEffects;

/// <summary>
/// When you put this creature into the battle zone, return x cards from your
/// mana zone to your hand. Then your opponent chooses x cards in his mana zone
/// and returns them to his hand.
/// </summary>
public sealed class MutualManaRecoveryEffect : OneShotEffect
{
    public int Amount { get; }

    public MutualManaRecoveryEffect(int amount)
    {
        Amount = amount;
    }

    public MutualManaRecoveryEffect(MutualManaRecoveryEffect effect)
    {
        Amount = effect.Amount;
    }

    public override void Apply(IGame game)
    {
        Controller.ReturnOwnManaCards(game, Ability, Amount);
        game.GetOpponent(Controller).ReturnOwnManaCards(game, Ability, Amount);
    }

    public override IOneShotEffect Copy()
    {
        return new MutualManaRecoveryEffect(this);
    }
}
