using Engine.Abilities;
using Interfaces;

namespace Cards.DM09;

public sealed class ZombieCarnivalEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var controller = Controller;
        var race = controller.ChooseRace(ToString());
        var creatures = controller.Graveyard.GetCreatures(race);
        game.Move(Ability, ZoneType.Graveyard, ZoneType.Hand, [.. controller.ChooseCards(creatures, 0, 3, ToString())]);
    }

    public override IOneShotEffect Copy()
    {
        return new ZombieCarnivalEffect();
    }

    public override string ToString()
    {
        return "Choose a race. Return up to 3 creatures of that race from your graveyard to your hand.";
    }
}
