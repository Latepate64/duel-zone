using Common;

namespace Cards.Cards.DM02
{
    class StainedGlass : Creature
    {
        public StainedGlass() : base("Stained Glass", 3, Civilization.Water, 1000, Subtype.CyberVirus)
        {
            // Whenever this creature attacks, you may choose one of your opponent's fire or nature creatures in the battle zone and return it to its owner's hand.
            Abilities.Add(new TriggeredAbilities.AttackAbility(new OneShotEffects.BounceEffect(0, 1, new CardFilters.OpponentsBattleZoneChoosableCreatureFilter(Civilization.Fire, Civilization.Nature))));
        }
    }
}
