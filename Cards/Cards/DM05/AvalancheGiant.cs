using Abilities.Triggered;
using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM05
{
    class AvalancheGiant : Engine.Creature
    {
        public AvalancheGiant() : base("Avalanche Giant", 6, 8000, Engine.Race.Giant, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddTriggeredAbility(new WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
