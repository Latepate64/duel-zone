using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public class OlgateAbility : DestroyedAbility
{
    public OlgateAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public OlgateAbility(OlgateAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new OlgateAbility(this);
    }

    public override string ToString()
    {
        return "Whenever one of your creatures is destroyed, you may untap this creature.";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card.Owner == Controller && card != Source;
    }
}
