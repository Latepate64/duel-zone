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
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new WindAxeTheWarriorSavageEffect()));
        }
    }
}
