using DuelMastersModels;

namespace Cards.Cards.DM03
{
    class MuramasaDukeOfBlades : Creature
    {
        public MuramasaDukeOfBlades() : base("Muramasa, Duke of Blades", 6, Civilization.Fire, 3000, Subtype.Human)
        {
            // Whenever this creature attacks, you may destroy one of your opponent's creatures that has power 2000 or less.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.DestroyEffect(new CardFilters.OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 0, 1, true)));
        }
    }
}
