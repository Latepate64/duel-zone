using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class PetrovaChannelerOfSuns : Creature
    {
        public PetrovaChannelerOfSuns() : base("Petrova, Channeler of Suns", 5, Civilization.Light, 3500, Subtype.MechaDelSol)
        {
            Abilities.Add(new PetrovaAbility());
            Abilities.Add(new UnchoosableAbility());
        }
    }
}
