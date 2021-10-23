using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class MistRiasSonicGuardian : Creature
    {
        public MistRiasSonicGuardian() : base("Mist Rias, Sonic Guardian", 5, Civilization.Light, 2000, Subtype.Guardian)
        {
            Abilities.Add(new AnotherCreaturePutIntoBattleZoneAbility(new ControllerMayDrawCardResolvable()));
        }
    }
}
