using Engine.Abilities;
using Interfaces;

namespace Cards.DM02;

public sealed class PlasmaChaserEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var amount = game.BattleZone.GetCreatureCount(GetOpponent(game).Id);

        if (amount > 0 && Controller.ChooseToTakeAction($"You may draw {amount} cards."))
        {
            Controller.DrawCards(amount, game, Ability);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new PlasmaChaserEffect();
    }

    public override string ToString()
    {
        return "You may draw a number of cards equal to the number of creatures your opponent has in the battle zone.";
    }
}
