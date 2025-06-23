using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class BombazarDragonOfDestiny : Creature
{
    public BombazarDragonOfDestiny() : base("Bombazar, Dragon of Destiny", 7, 6000,
        [Race.ArmoredDragon, Race.EarthDragon], Civilization.Fire, Civilization.Nature)
    {
        AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
        AddStaticAbilities(new DoubleBreakerEffect());
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BombazarDragonOfDestinyEffect()));
    }
}
