using DuelMastersModels.Abilities.Trigger;
using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone
    {
        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        internal BattleZone(Player owner) : base(owner) { }

        internal override void Add(Card card, Duel duel)
        {
            if (card is Creature creature)
            {
                creature.SummoningSickness = true;
            }
            Cards.Add(card);
            card.KnownToOwner = true;
            card.KnownToOpponent = true;
            foreach (TriggerAbility ability in card.TriggerAbilities.Where(ability => ability.TriggerCondition is WhenYouPutThisCreatureIntoTheBattleZone))
            {
                duel.TriggerTriggerAbility(ability, Owner);
            }
            foreach (Creature battleZoneCreature in duel.CreaturesInTheBattleZone.Except(new List<Card>() { card }))
            {
                foreach (TriggerAbility ability in battleZoneCreature.TriggerAbilities.Where(ability => ability.TriggerCondition is WheneverAnotherCreatureIsPutIntoTheBattleZone))
                {
                    duel.TriggerTriggerAbility(ability, ability.Controller);
                }
            }
        }

        internal override void Remove(Card card, Duel duel)
        {
            Cards.Remove(card);
            card.Tapped = false;
            if (card is Creature creature)
            {
                creature.SummoningSickness = true;
            }
        }
    }
}