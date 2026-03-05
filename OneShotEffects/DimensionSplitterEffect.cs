using Interfaces;

namespace OneShotEffects;

public sealed class DimensionSplitterEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        if (Controller.ChooseToTakeAction(ToString()))
        {
            game.Move(Ability, ZoneType.Graveyard, ZoneType.Hand, [.. Controller.Graveyard.Dragons]);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new DimensionSplitterEffect();
    }

    public override string ToString()
    {
        return "You may return all creatures that have Dragon in their race from your graveyard to your hand.";
    }
}
