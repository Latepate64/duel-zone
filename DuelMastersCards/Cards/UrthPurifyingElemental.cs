using DuelMastersCards.Resolvables;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class UrthPurifyingElemental : Creature
    {
        public UrthPurifyingElemental() : base("Urth, Purifying Elemental", 6, Civilization.Light, 6000, Subtype.AngelCommand)
        {
            Abilities.Add(new DoubleBreakerAbility());
            Abilities.Add(new AtTheEndOfYourTurnAbility(new ControllerMayUntapCreatureResolvable()));
        }
    }
}
