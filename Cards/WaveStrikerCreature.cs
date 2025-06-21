using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards;

class WaveStrikerCreature(string name, int manaCost, int power, Race race, Civilization civilization) : Creature(
    name, manaCost, power, race, civilization)
{
    protected void AddWaveStrikerAbility(params IContinuousEffect[] effects)
    {
        AddAbilities(new StaticAbility(new WaveStrikerEffect([.. effects.Select(x => new StaticAbility(x))])));
    }

    protected void AddWaveStrikerAbility(ITriggeredAbility ability)
    {
        AddAbilities(new StaticAbility(new WaveStrikerEffect(ability)));
    }
}