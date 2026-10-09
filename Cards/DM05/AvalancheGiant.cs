using Abilities.Static;
using ContinuousEffects.CannotAttackCreatures;
using TriggeredAbilities;

namespace Cards.DM05
{
    sealed class AvalancheGiant : Creature
    {
        public AvalancheGiant() : base("Avalanche Giant", 6, 8000, Interfaces.Race.Giant, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddTriggeredAbility(new WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldEffect()));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
