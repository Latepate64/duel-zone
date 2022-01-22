using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using System.Collections.Generic;

namespace DuelMastersCards.Cards
{
    public class WindAxeTheWarriorSavage : Creature
    {
        public WindAxeTheWarriorSavage() : base("Wind Axe, the Warrior Savage", 5, new List<Civilization> { Civilization.Fire, Civilization.Nature }, 2000, new List<Subtype> { Subtype.Human, Subtype.BeastFolk })
        {
            // When you put this creature into the battle zone, destroy one of your opponent's creatures that has "blocker." Then put the top card of your deck into your mana zone.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new WindAxeTheWarriorSavageEffect()));
        }
    }
}
