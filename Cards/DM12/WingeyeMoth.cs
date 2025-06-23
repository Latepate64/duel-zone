using Engine;
using Interfaces;

namespace Cards.DM12;

public sealed class WingeyeMoth : Creature
{
    public WingeyeMoth() : base("Wingeye Moth", 5, 3000, Race.GiantInsect, Civilization.Nature)
    {
        AddTriggeredAbility(new WingeyeMothAbility());
    }
}
