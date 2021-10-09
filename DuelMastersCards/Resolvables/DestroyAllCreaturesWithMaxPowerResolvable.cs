using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class DestroyAllCreaturesWithMaxPowerResolvable : Resolvable
    {
        public int MaxPower { get; }

        public DestroyAllCreaturesWithMaxPowerResolvable(int maxPower)
        {
            MaxPower = maxPower;
        }

        public DestroyAllCreaturesWithMaxPowerResolvable(DestroyAllCreaturesWithMaxPowerResolvable resolvable) : base(resolvable)
        {
            MaxPower = resolvable.MaxPower;
        }

        public override Resolvable Copy()
        {
            return new DestroyAllCreaturesWithMaxPowerResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            duel.Destroy(duel.CreaturePermanents.Where(x => duel.GetPower(x) <= MaxPower).ToList());
            return null;
        }
    }
}
