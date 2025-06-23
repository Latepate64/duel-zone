using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class TajimalVizierOfAqua : Creature
{
    public TajimalVizierOfAqua() : base(
        "Tajimal, Vizier of Aqua", 3, 4000, [Race.Initiate, Race.LiquidPeople], Civilization.Light, Civilization.Water)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        AddStaticAbilities(new TajimalEffect());
    }
}
