using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class SoulswapResolvable : Resolvable
    {
        public SoulswapResolvable()
        {
        }

        public SoulswapResolvable(SoulswapResolvable resolvable) : base(resolvable)
        {
            _soulswapState = resolvable._soulswapState;
        }

        public override Resolvable Copy()
        {
            return new SoulswapResolvable(this);
        }

        public override void Resolve(Duel duel, Decision decision)
        {
            // You may choose a creature in the battle zone and put it into its owner's mana zone.
            if (decision == null)
            {
                ChooseCreatureInTheBattleZone(duel);
            }
            else if (_soulswapState == SoulswapState.FromBattleZoneToMana)
            {
                PutFromBattleZoneIntoManaZone(duel, decision);
            }
            else if (_soulswapState == SoulswapState.FromManaToBattleZone)
            {
                PutFromManaZoneToBattleZone(duel, decision);
            }
            else if (_soulswapState == SoulswapState.PermanentEnteringBattleZone)
            {
                duel.Players.Select(x => x.BattleZone).Single(x => x.PermanentEnteringBattleZone != null).Add(duel, decision);
            }
            else
            {
                throw new System.ArgumentOutOfRangeException(_soulswapState.ToString());
            }
        }

        private void PutFromManaZoneToBattleZone(Duel duel, Decision decision)
        {
            var mana = duel.GetCard(((GuidDecision)decision).Decision.Single());
            duel.Move(mana, ZoneType.ManaZone, ZoneType.BattleZone);
        }

        private void ChooseCreatureInTheBattleZone(Duel duel)
        {
            var creatures = duel.GetChoosableCreaturePermanents(duel.GetPlayer(Controller));
            if (creatures.Any())
            {
                duel.SetAwaitingChoice(new GuidSelection(Controller, creatures, 0, 1));
            }
        }

        private void PutFromBattleZoneIntoManaZone(Duel duel, Decision decision)
        {
            var creatures = ((GuidDecision)decision).Decision;
            if (creatures.Any())
            {
                PutFromBattleZoneIntoManaZone(duel, creatures);
            }
        }

        private void PutFromBattleZoneIntoManaZone(Duel duel, IEnumerable<Guid> creatures)
        {
            var creature = duel.GetPermanent(creatures.Single());
            var owner = duel.GetPlayer(creature.Owner);
            duel.Move(creature, ZoneType.BattleZone, ZoneType.ManaZone);

            // If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
            _soulswapState = SoulswapState.FromManaToBattleZone;
            var manas = owner.ManaZone.Creatures.Where(c => c.ManaCost <= owner.ManaZone.Cards.Count); //TODO: Check that is not evolution creature
            if (manas.Any())
            {
                PutFromManaZoneIntoBattleZone(duel, manas);
            }
        }

        private void PutFromManaZoneIntoBattleZone(Duel duel, IEnumerable<Card> manas)
        {
            if (manas.Count() > 1)
            {
                duel.SetAwaitingChoice(new GuidSelection(Controller, manas, 1, 1));
            }
            else
            {
                duel.Move(manas, ZoneType.ManaZone, ZoneType.BattleZone);
            }
        }

        private SoulswapState _soulswapState = SoulswapState.FromBattleZoneToMana;

        private enum SoulswapState { FromBattleZoneToMana, FromManaToBattleZone, PermanentEnteringBattleZone }
    }
}
