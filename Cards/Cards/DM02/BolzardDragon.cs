using Common;

namespace Cards.Cards.DM02
{
    class BolzardDragon : Creature
    {
        public BolzardDragon() : base("Bolzard Dragon", 6, Common.Civilization.Fire, 5000, Common.Subtype.ArmoredDragon)
        {
            // Whenever this creature attacks, choose a card in your opponent's mana zone and put it into his graveyard.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.ManaBurnEffect(new CardFilters.OpponentsManaZoneCardFilter(), 1, 1, true)));
        }
    }
}
