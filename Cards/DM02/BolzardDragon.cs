using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class BolzardDragon : Creature
{
    public BolzardDragon() : base("Bolzard Dragon", 6, 5000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new ManaBurnEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    ownMana: false
        )));
    }
}