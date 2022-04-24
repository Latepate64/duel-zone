using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM12
{
    class CruelNagaAvatarOfFate : VortexEvolutionCreature
    {
        public CruelNagaAvatarOfFate() : base("Cruel Naga, Avatar of Fate", 6, 9000, Civilization.Water, Civilization.Darkness, Race.Naga, Race.Merfolk, Race.Chimera)
        {
            AddThisCreatureCannotBeBlockedAbility();
            AddDoubleBreakerAbility();
            AddTriggeredAbility(new WhenThisCreatureLeavesBattleZoneAbility(new OneShotEffects.DestroyAllCreaturesEffect()));
        }
    }
}
