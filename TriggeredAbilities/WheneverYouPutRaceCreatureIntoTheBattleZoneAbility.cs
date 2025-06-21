using Engine;
using Engine.Abilities;

namespace TriggeredAbilities;

public class WheneverYouPutRaceCreatureIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
{
    private readonly Race _race;

    public WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(
        WheneverYouPutRaceCreatureIntoTheBattleZoneAbility ability) : base(ability)
    {
        _race = ability._race;
    }

    public WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(Race race, IOneShotEffect effect) : base(effect)
    {
        _race = race;
    }

    public override IAbility Copy()
    {
        return new WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever you put a {_race} into the battle zone, {GetEffectText()}";
    }

    protected override bool TriggersFrom(Creature card, IGame game)
    {
        return Controller == card.Owner && card.HasRace(_race);
    }
}
