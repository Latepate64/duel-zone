using DuelMastersCards.OneShotEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using System.Collections.Generic;

namespace DuelMastersCards.Cards
{
    public class BombazarDragonOfDestiny : Creature
    {
        public BombazarDragonOfDestiny() : base("Bombazar, Dragon of Destiny", 7, new List<Civilization> { Civilization.Fire, Civilization.Nature }, 6000, new List<Subtype> { Subtype.ArmoredDragon, Subtype.EarthDragon })
        {
            Abilities.Add(new SpeedAttackerAbility());
            Abilities.Add(new DoubleBreakerAbility());
            // When you put this creature into the battle zone, destroy all other creatures that have 6000 power. Take an extra turn after this one. You lose the game at the end of that turn.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BombazarDragonOfDestinyEffect()));
        }
    }
}
