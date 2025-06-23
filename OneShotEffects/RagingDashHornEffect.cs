using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class RagingDashHornEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
{
    public RagingDashHornEffect() : base() { }

    public RagingDashHornEffect(RagingDashHornEffect effect) : base(effect) { }

    public void AddAbility(IGame game)
    {
        if (Applies(game))
        {
            Source.AddGrantedAbility(new StaticAbility(new DoubleBreakerEffect()));
        }
    }

    public override IContinuousEffect Copy()
    {
        return new RagingDashHornEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        if (Applies(game))
        {
            (Source as ICreature).IncreasePower(3000);
        }
    }

    public override string ToString()
    {
        return "While all the cards in your mana zone are nature cards, this creature gets +3000 power and has \"double breaker.\"";
    }

    private bool Applies(IGame game)
    {
        return Ability != null && Ability.Controller.ManaZone.AreAllCivilizationCards(Civilization.Nature);
    }
}
