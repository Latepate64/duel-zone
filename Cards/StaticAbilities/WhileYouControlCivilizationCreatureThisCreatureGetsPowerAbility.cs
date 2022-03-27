using Common;

namespace Cards.StaticAbilities
{
    class WhileYouControlCivilizationCreatureThisCreatureGetsPowerAbility : Engine.Abilities.StaticAbility
    {
        public WhileYouControlCivilizationCreatureThisCreatureGetsPowerAbility(Civilization civilization, int power) : base(new ContinuousEffects.WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(civilization, power))
        {
        }
    }
}