using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM05
{
    class AvalancheGiant : Engine.Creature
    {
        public AvalancheGiant() : base("Avalanche Giant", 6, 8000, Interfaces.Race.Giant, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddTriggeredAbility(new WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
