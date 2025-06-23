using Engine;
using Engine.Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class TechnoTotem : Creature
{
    public TechnoTotem() : base("Techno Totem", 4, 5000, Race.MysteryTotem, Civilization.Light, Civilization.Nature)
    {
        AddStaticAbilities(new TechnoTotemEffect());
        AddAbilities(new TapAbility(new ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
    }
}
