using Abilities.Static;
using ContinuousEffects.CannotUseCard;
using Interfaces;

namespace Cards.DM04;

public sealed class AlcadeiasLordOfSpirits : EvolutionCreature
{
    public AlcadeiasLordOfSpirits() : base(
        "Alcadeias, Lord of Spirits", 6, 12500, Race.AngelCommand, Civilization.Light)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddStaticAbilities(new AlcadeiasLordOfSpiritsEffect());
    }
}
