using DuelMastersCards.CardFilters;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.Cards
{
    public class BolshackDragon : Creature
    {
        public BolshackDragon() : base("Bolshack Dragon", 6, Civilization.Fire, 6000, Subtype.ArmoredDragon)
        {
            Abilities.Add(new BolshackDragonAbility());
            Abilities.Add(new DoubleBreakerAbility());
        }
    }

    public class BolshackDragonAbility : StaticAbility
    {
        public BolshackDragonAbility()
        {
            ContinuousEffects.Add(new BolshackDragonEffect());
        }

        public BolshackDragonAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new BolshackDragonAbility(this);
        }
    }

    public class BolshackDragonEffect : PowerModifyingEffect
    {
        public BolshackDragonEffect() : base(new List<CardFilter> { new AttackingCreatureFilter(), new TargetFilter() }, 0, new Indefinite())
        {
        }

        public override int GetPower(Duel duel)
        {
            //this creature gets +1000 power for each fire card in your graveyard.
            return duel.GetPlayer(Controller).Graveyard.Cards.Where(x => x.Civilizations.Contains(Civilization.Fire)).Count() * 1000;
        }
    }
}
