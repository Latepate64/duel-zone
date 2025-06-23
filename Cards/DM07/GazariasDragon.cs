using ContinuousEffects;
using Interfaces;

namespace Cards.DM07;

sealed class GazariasDragon : Creature
{
    public GazariasDragon() : base("Gazarias Dragon", 5, 4000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(new GazariasDragonEffect());
    }
}
