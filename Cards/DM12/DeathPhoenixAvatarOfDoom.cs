using TriggeredAbilities;
using Interfaces;
using Abilities.Static;
using ContinuousEffects.Replacement;

namespace Cards.DM12
{
    sealed class DeathPhoenixAvatarOfDoom : VortexEvolutionCreature
    {
        public DeathPhoenixAvatarOfDoom() : base("Death Phoenix, Avatar of Doom", 4, 9000, Civilization.Darkness, Civilization.Fire, Race.Phoenix, Race.ZombieDragon, Race.FireBird)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddStaticAbilities(new BolmeteusEffect());
            AddTriggeredAbility(new WhenThisCreatureLeavesBattleZoneAbility(new OneShotEffects.YourOpponentDiscardsHisHandEffect()));
        }
    }
}
