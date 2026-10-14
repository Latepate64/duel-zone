using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class BakkraHornTheSilent : Creature
{
    public BakkraHornTheSilent() : base("Bakkra Horn, the Silent", 4, 2000,
        Race.HornedBeast, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(
                new PutTopCardsOfDeckIntoManaZoneEffect(1)));
    }
}