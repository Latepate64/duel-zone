using Engine.Abilities;
using System.Linq;
using Interfaces;

namespace Cards.DM06;

public class QTronicHypermindEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        Controller.DrawCardsOptionally(game, Ability, game.BattleZone.GetCreatures(Race.Survivor).Count());
    }

    public override IOneShotEffect Copy()
    {
        return new QTronicHypermindEffect();
    }

    public override string ToString()
    {
        return "You may draw a card for each Survivor in the battle zone.";
    }
}
