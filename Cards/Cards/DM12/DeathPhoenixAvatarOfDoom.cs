using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM12
{
    class DeathPhoenixAvatarOfDoom : VortexEvolutionCreature
    {
        public DeathPhoenixAvatarOfDoom() : base("Death Phoenix, Avatar of Doom", 4, 9000, Civilization.Darkness, Civilization.Fire, Race.Phoenix, Race.ZombieDragon, Race.FireBird)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new BolmeteusEffect());
            AddTriggeredAbility(new TriggeredAbilities.WhenThisCreatureLeavesBattleZoneAbility(new OneShotEffects.YourOpponentDiscardsHisHandEffect()));
        }
    }
}
