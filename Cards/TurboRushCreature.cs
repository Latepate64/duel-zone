using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards;

class TurboRushCreature(string name, int manaCost, int power, Race race, params Civilization[] civilizations) : Creature(name, manaCost, power, race, civilizations)
{
    protected void AddTurboRushAbility(ITriggeredAbility ability)
    {
        AddStaticAbilities(new TurboRushEffect(ability));
    }

    protected void AddTurboRushAbility(IContinuousEffect effect)
    {
        AddStaticAbilities(new TurboRushEffect(new StaticAbility(effect)));
    }
}