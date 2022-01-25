using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards.DM01
{
    public class DarkClown : Creature
    {
        public DarkClown() : base("Dark Clown", 4, Civilization.Darkness, 6000, Subtype.BrainJacker)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());

            // When this creature wins a battle, destroy it.
            var targetFilter = new TargetFilter();
            Abilities.Add(new WinBattleAbility(new CardMovingAreaOfEffect(ZoneType.BattleZone, ZoneType.Graveyard, targetFilter), targetFilter));
        }
    }
}
