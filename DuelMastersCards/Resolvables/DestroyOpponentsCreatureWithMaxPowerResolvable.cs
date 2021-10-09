using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class DestroyOpponentsCreatureWithMaxPowerResolvable : Resolvable
    {
        public int MaxPower { get; }

        public DestroyOpponentsCreatureWithMaxPowerResolvable(int maxPower)
        {
            MaxPower = maxPower;
        }

        public DestroyOpponentsCreatureWithMaxPowerResolvable(DestroyOpponentsCreatureWithMaxPowerResolvable resolvable) : base(resolvable)
        {
            MaxPower = resolvable.MaxPower;
        }

        public override Resolvable Copy()
        {
            return new DestroyOpponentsCreatureWithMaxPowerResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                var opponent = duel.GetOpponent(duel.GetPlayer(Controller));
                var permanents = opponent.BattleZone.Permanents.Where(x => duel.GetPower(x) <= MaxPower);
                if (permanents.Count() > 1)
                {
                    return new GuidSelection(Controller, permanents, 1, 1);
                }
                else if (permanents.Any())
                {
                    duel.Destroy(permanents.Single());
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                duel.Destroy(duel.GetPermanent((decision as GuidDecision).Decision.Single()));
                return null;
            }
        }
    }
}
