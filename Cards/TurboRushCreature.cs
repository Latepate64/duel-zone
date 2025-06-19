using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;

namespace Cards;

class TurboRushCreature(string name, int manaCost, int power, Race race, params Civilization[] civilizations) : Creature(name, manaCost, power, race, civilizations)
{
    protected void AddTurboRushAbility(ITriggeredAbility ability)
    {
        AddStaticAbilities(new TurboRushEffect(ability));
    }

    protected void AddTurboRushAbility(Engine.ContinuousEffects.IContinuousEffect effect)
    {
        AddStaticAbilities(new TurboRushEffect(new StaticAbility(effect)));
    }
}