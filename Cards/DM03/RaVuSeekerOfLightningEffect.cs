using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Cards.DM03;

public class RaVuSeekerOfLightningEffect : SalvageEffect
{
    public RaVuSeekerOfLightningEffect() : base(0, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new RaVuSeekerOfLightningEffect();
    }

    public override string ToString()
    {
        return "You may return a light spell from your graveyard to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.Spells.Where(x => x.HasCivilization(Civilization.Light));
    }
}
