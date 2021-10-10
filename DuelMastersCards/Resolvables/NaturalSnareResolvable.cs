﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    class NaturalSnareResolvable : Resolvable
    {
        public NaturalSnareResolvable()
        {
        }

        public NaturalSnareResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new NaturalSnareResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            var opponent = duel.GetOpponent(duel.GetPlayer(Controller));
            if (decision == null)
            {
                if (opponent.BattleZone.Permanents.Count() > 1)
                {
                    return new GuidSelection(Controller, opponent.BattleZone.Permanents, 1, 1);
                }
                else if (opponent.BattleZone.Permanents.Any())
                {
                    opponent.PutFromBattleZoneIntoManaZone(opponent.BattleZone.Permanents.Single(), duel);
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                opponent.PutFromBattleZoneIntoManaZone(duel.GetPermanent((decision as GuidDecision).Decision.Single()), duel);
                return null;
            }
        }
    }
}