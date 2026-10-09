using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM10;

public sealed class BombazarDragonOfDestiny : Creature
{
    public BombazarDragonOfDestiny() : base("Bombazar, Dragon of Destiny", 7, 6000,
        [Race.ArmoredDragon, Race.EarthDragon], Civilization.Fire, Civilization.Nature)
    {
        AddAbilities(new SpeedAttackerAbility(), new DoubleBreakerAbility());
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BombazarDragonOfDestinyEffect()));
    }
}
