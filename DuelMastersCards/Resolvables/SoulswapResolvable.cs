using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
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

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // You may choose a creature in the battle zone and put it into its owner's mana zone.
            if (decision == null)
            {
                return ChooseCreatureInTheBattleZone(duel);
            }
            else if (_soulswapState == SoulswapState.FromBattleZoneToMana)
            {
                return PutFromBattleZoneIntoManaZone(duel, decision);
            }
            else if (_soulswapState == SoulswapState.FromManaToBattleZone)
            {
                return PutFromManaZoneToBattleZone(duel, decision);
            }
            else if (_soulswapState == SoulswapState.PermanentEnteringBattleZone)
            {
                duel.Players.Select(x => x.BattleZone).Single(x => x.PermanentEnteringBattleZone != null).Add(duel, decision);
                return null;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException(_soulswapState.ToString());
            }
        }

        private Choice PutFromManaZoneToBattleZone(Duel duel, Decision decision)
        {
            var mana = duel.GetCard(((GuidDecision)decision).Decision.Single());
            var dec = duel.GetOwner(mana).PutFromManaZoneIntoBattleZone(mana, duel);
            if (dec == null)
            {
                return null;
            }
            else
            {
                _soulswapState = SoulswapState.PermanentEnteringBattleZone;
                return dec;
            }
        }

        private Choice ChooseCreatureInTheBattleZone(Duel duel)
        {
            var creatures = duel.GetChoosableCreaturePermanents(duel.GetPlayer(Controller));
            if (creatures.Any())
            {
                return new GuidSelection(Controller, creatures, 0, 1);
            }
            else
            {
                return null;
            }
        }

        private Choice PutFromBattleZoneIntoManaZone(Duel duel, Decision decision)
        {
            var creatures = ((GuidDecision)decision).Decision;
            if (creatures.Any())
            {
                return PutFromBattleZoneIntoManaZone(duel, creatures);
            }
            else
            {
                return null;
            }
        }

        private Choice PutFromBattleZoneIntoManaZone(Duel duel, IEnumerable<Guid> creatures)
        {
            var creature = duel.GetPermanent(creatures.Single());
            var owner = duel.GetPlayer(creature.Owner);
            owner.PutFromBattleZoneIntoManaZone(creature, duel);

            // If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
            _soulswapState = SoulswapState.FromManaToBattleZone;
            var manas = owner.ManaZone.Creatures.Where(c => c.ManaCost <= owner.ManaZone.Cards.Count); //TODO: Check that is not evolution creature
            if (manas.Any())
            {
                return PutFromManaZoneIntoBattleZone(duel, manas);
            }
            else
            {
                return null;
            }
        }

        private Choice PutFromManaZoneIntoBattleZone(Duel duel, IEnumerable<Card> manas)
        {
            if (manas.Count() > 1)
            {
                return new GuidSelection(Controller, manas, 1, 1);
            }
            else
            {
                var target = manas.Single();
                duel.GetOwner(target).PutFromManaZoneIntoBattleZone(target, duel);
                return null;
            }
        }

        private SoulswapState _soulswapState = SoulswapState.FromBattleZoneToMana;

        private enum SoulswapState { FromBattleZoneToMana, FromManaToBattleZone, PermanentEnteringBattleZone }
    }
}
