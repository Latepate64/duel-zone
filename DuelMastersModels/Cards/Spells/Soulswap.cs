using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersModels.Cards.Spells
{
    public class Soulswap : Spell
    {
        public Soulswap(Guid owner) : base(owner, 3, Civilization.Nature)
        {
            ShieldTrigger = true;
            SpellAbilities.Add(new SoulswapAbility(Id, owner));
        }

        public Soulswap(Spell spell) : base(spell)
        {
        }

        public override Card Copy()
        {
            return new Soulswap(this);
        }
    }

    public class SoulswapAbility : SpellAbility
    {
        public SoulswapAbility(Guid source, Guid controller) : base(source, controller)
        {
        }

        public SoulswapAbility(SoulswapAbility ability) : base(ability)
        {
            _firstPart = ability._firstPart;
        }

        public override NonStaticAbility Copy()
        {
            return new SoulswapAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // You may choose a creature in the battle zone and put it into its owner's mana zone.
            if (decision == null)
            {
                if (duel.BattleZoneCreatures.Any())
                {
                    return new Selection<Guid>(Controller, duel.BattleZoneCreatures.Select(x => x.Id));
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
                    var creature = duel.GetCreature(creatures.Single());
                    var owner = duel.GetOwner(creature);
                    owner.PutFromBattleZoneIntoManaZone(creature, duel);

                    // If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
                    _firstPart = false;
                    var manas = owner.ManaZone.Creatures.Where(c => !(c is EvolutionCreature) && c.Cost <= owner.ManaZone.Cards.Count());
                    if (manas.Any())
                    {
                        if (manas.Count() > 1)
                        {
                            return new Selection<Guid>(Controller, manas.Select(x => x.Id), 1, 1);
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
                var mana = duel.GetCreature(((GuidDecision)decision).Decision.Single());
                duel.GetOwner(mana).PutFromManaZoneIntoBattleZone(mana, duel);
                return null;
            }
        }

        private bool _firstPart = true;
    }
}
