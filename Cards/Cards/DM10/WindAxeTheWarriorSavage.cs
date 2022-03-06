using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM10
{
    class WindAxeTheWarriorSavage : Creature
    {
        public WindAxeTheWarriorSavage() : base("Wind Axe, the Warrior Savage", 5, 2000, Civilization.Fire, Civilization.Nature)
        {
            AddSubtypes(Subtype.Human, Subtype.BeastFolk);
            // When you put this creature into the battle zone, destroy one of your opponent's creatures that has "blocker." Then put the top card of your deck into your mana zone.
            Abilities.Add(new PutIntoPlayAbility(new WindAxeTheWarriorSavageEffect()));
        }
    }
}
