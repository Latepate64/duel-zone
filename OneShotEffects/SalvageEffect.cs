using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Salvage is a term for returning a card from your graveyard to your hand.
/// </summary>
public abstract class SalvageEffect : CardMovingChoiceEffect<ICard>
{
    protected SalvageEffect(int minimum, int maximum, bool controllerChooses) : base(
        minimum, maximum, controllerChooses, ZoneType.Graveyard, ZoneType.Hand)
    {
    }

    protected SalvageEffect(SalvageEffect effect) : base(effect)
    {
    }
}
