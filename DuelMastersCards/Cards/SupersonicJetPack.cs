using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class SupersonicJetPack : Spell
    {
        public SupersonicJetPack() : base("Supersonic Jet Pack", 1, Civilization.Fire)
        {
            Abilities.Add(new SpellAbility(new SupersonicJetPackResolvable()));
        }
    }
}
