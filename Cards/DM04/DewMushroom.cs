using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM04;

public class DewMushroom : Creature
{
    public DewMushroom() : base("Dew Mushroom", 3, 1000, Race.BalloonMushroom, Civilization.Nature)
    {
        AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(1, Civilization.Darkness));
    }
}
