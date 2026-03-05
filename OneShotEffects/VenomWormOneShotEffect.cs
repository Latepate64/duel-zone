using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class VenomWormOneShotEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id).Where(x => x.HasRace(race)).ToArray();
        game.AddContinuousEffects(Ability, new VenomWormContinuousEffect(race, creatures));
    }

    public override IOneShotEffect Copy()
    {
        return new VenomWormOneShotEffect();
    }

    public override string ToString()
    {
        return "Choose a race. Each creature of that race gets \"slayer\" until the end of the turn.";
    }
}
