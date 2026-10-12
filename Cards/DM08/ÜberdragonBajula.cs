using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class ÜberdragonBajula : DragonEvolutionCreature
{
    public ÜberdragonBajula() : base("Überdragon Bajula", 7, 13000,
        Race.ArmoredDragon, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new ManaBurnEffect(
                    minimum: 0,
                    maximum: 2,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    ownMana: false
        )));
    }
}