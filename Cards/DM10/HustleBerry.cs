using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class HustleBerry : SilentSkillCreature
{
    public HustleBerry() : base("Hustle Berry", 2, 1000, Race.WildVeggies,
        Civilization.Nature)
    {
        AddSilentSkillAbility(
            new PutTopCardsOfDeckIntoManaZoneEffect(1));
    }
}