using Cards.CardFilters;

namespace Cards.Cards.DM03
{
    class MuramasaDukeOfBlades : Creature
    {
        public MuramasaDukeOfBlades() : base("Muramasa, Duke of Blades", 6, 3000, Common.Subtype.Human, Common.Civilization.Fire)
        {
            // Whenever this creature attacks, you may destroy one of your opponent's creatures that has power 2000 or less.
            Abilities.Add(new TriggeredAbilities.AttackAbility(new OneShotEffects.DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 0, 1, true)));
        }
    }
}
