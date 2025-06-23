using Interfaces;

namespace Cards.DM08;

public sealed class MissileSoldierUltimo : TurboRushCreature
{
    public MissileSoldierUltimo() : base("Missile Soldier Ultimo", 3, 2000, Race.Dragonoid, Civilization.Fire)
    {
        AddTurboRushAbility(new MissileSoldierUltimoEffect());
    }
}
