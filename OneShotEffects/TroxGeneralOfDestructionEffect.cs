using Interfaces;

namespace OneShotEffects;

public sealed class TroxGeneralOfDestructionEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var amount = game.BattleZone.GetCreatures(Ability.Controller.Id).Count(
            x => x != Ability.Source && x.HasCivilization(Civilization.Darkness));
        GetOpponent(game).DiscardAtRandom(game, amount, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new TroxGeneralOfDestructionEffect();
    }

    public override string ToString()
    {
        return "Your opponent discards a card at random from his hand for each other darkness creature you have in the battle zone.";
    }
}
