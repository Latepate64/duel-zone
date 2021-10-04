﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
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
            _firstPart = resolvable._firstPart;
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
                if (duel.CreaturePermanents.Any())
                {
                    return new GuidSelection(Controller, duel.CreaturePermanents, 0, 1);
                }
                else
                {
                    return null;
                }
            }
            else if (_firstPart)
            {
                var creatures = ((GuidDecision)decision).Decision;
                if (creatures.Any())
                {
                    var creature = duel.GetPermanent(creatures.Single());
                    var owner = duel.GetPlayer(creature.Controller);
                    owner.PutFromBattleZoneIntoManaZone(creature, duel);

                    // If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
                    _firstPart = false;
                    var manas = owner.ManaZone.Creatures.Where(c => c.ManaCost <= owner.ManaZone.Cards.Count); //TODO: Check that is not evolution creature
                    if (manas.Any())
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
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                var mana = duel.GetCard(((GuidDecision)decision).Decision.Single());
                duel.GetOwner(mana).PutFromManaZoneIntoBattleZone(mana, duel);
                return null;
            }
        }

        private bool _firstPart = true;
    }
}