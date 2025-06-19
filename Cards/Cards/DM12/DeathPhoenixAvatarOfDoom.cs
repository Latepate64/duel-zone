using Cards.ContinuousEffects;
using Effects.Continuous;
using Engine;

namespace Cards.Cards.DM12
{
    class DeathPhoenixAvatarOfDoom : VortexEvolutionCreature
    {
        public DeathPhoenixAvatarOfDoom() : base("Death Phoenix, Avatar of Doom", 4, 9000, Civilization.Darkness, Civilization.Fire, Race.Phoenix, Race.ZombieDragon, Race.FireBird)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new BolmeteusEffect());
            AddTriggeredAbility(new TriggeredAbilities.WhenThisCreatureLeavesBattleZoneAbility(new OneShotEffects.YourOpponentDiscardsHisHandEffect()));
        }
    }
}
