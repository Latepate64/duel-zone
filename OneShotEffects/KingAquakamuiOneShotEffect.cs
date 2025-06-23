using Interfaces;

namespace OneShotEffects;

public sealed class KingAquakamuiOneShotEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        if (Controller.ChooseToTakeAction(ToString()))
        {
            game.Move(Ability, ZoneType.Graveyard, ZoneType.Hand, [.. Controller.Graveyard.GetCreatures(
                Race.AngelCommand, Race.DemonCommand)]);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new KingAquakamuiOneShotEffect();
    }

    public override string ToString()
    {
        return "You may return all Angel Commands and all Demon Commands from your graveyard to your hand.";
    }
}
