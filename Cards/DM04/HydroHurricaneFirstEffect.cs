using Engine.Abilities;
using Interfaces;
using System.Linq;

namespace Cards.DM04;

public class HydroHurricaneFirstEffect : OneShotEffect
{
    public HydroHurricaneFirstEffect()
    {
    }

    public HydroHurricaneFirstEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var controller = Controller;
        var amount = game.BattleZone.GetCreatures(controller.Id).Count(x => x.HasCivilization(Civilization.Light));
        var cards = controller.ChooseCards(GetOpponent(game).ManaZone.Cards, 0, amount, ToString()).ToArray();
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, cards);
    }

    public override IOneShotEffect Copy()
    {
        return new HydroHurricaneFirstEffect(this);
    }

    public override string ToString()
    {
        return "For each light creature you have in the battle zone, you may choose a card in your opponent's mana zone and return it to his hand.";
    }
}
