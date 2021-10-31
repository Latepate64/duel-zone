using DuelMastersCards.CardFilters;
using DuelMastersCards.ContinuousEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class BolshackDragon : Creature
    {
        public BolshackDragon() : base("Bolshack Dragon", 6, Civilization.Fire, 6000, Subtype.ArmoredDragon)
        {
            var ability = new StaticAbility();
            ability.ContinuousEffects.Add(new PowerModifyingMultiplierEffect(new CivilizationFilter(Civilization.Fire)));
            Abilities.Add(ability);
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}