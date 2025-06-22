using Engine.Choices;
using Interfaces;

namespace Cards.DM12;

public class MechadragonsBreathChoice : NumberChoice
{
    public MechadragonsBreathChoice(NumberChoice choice) : base(choice)
    {
    }

    public MechadragonsBreathChoice(IPlayer maker, string description) : base(maker, description)
    {
    }

    public override bool IsValid()
    {
        return base.IsValid() && Choice <= 6000;
    }
}
