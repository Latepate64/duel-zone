using Abilities.Static;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards;

class WaveStrikerCreature(string name, int manaCost, int power, Race race, Civilization civilization) : Creature(name, manaCost, power, race, civilization)
{
    protected void AddWaveStrikerAbility(params Engine.ContinuousEffects.IContinuousEffect[] effects)
    {
        AddAbilities(new WaveStrikerAbility([.. effects.Select(x => new StaticAbility(x))]));
    }

    protected void AddWaveStrikerAbility(ITriggeredAbility ability)
    {
        AddAbilities(new WaveStrikerAbility(ability));
    }
}