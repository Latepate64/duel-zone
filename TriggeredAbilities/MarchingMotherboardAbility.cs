using Engine;
using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public class MarchingMotherboardAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
{
    public MarchingMotherboardAbility(MarchingMotherboardAbility ability) : base(ability)
    {
    }

    public MarchingMotherboardAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public override IAbility Copy()
    {
        return new MarchingMotherboardAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever you put another creature that has Cyber in its race into the battle zone, {GetEffectText()}";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card.Owner == Controller && card != Source && card.Races.Intersect(
            [Race.CyberCluster, Race.CyberLord, Race.CyberMoon, Race.CyberVirus]).Any();
    }
}
