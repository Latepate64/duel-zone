using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07;

public class BexTheOracleEffect : ContinuousEffect, IAbilityAddingEffect
{
    /// <summary>
    /// While you have no shields, this creature has "Blocker."
    /// </summary>
    public BexTheOracleEffect() : base()
    {
    }

    BexTheOracleEffect(BexTheOracleEffect effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        if (!Ability.Source.Owner.ShieldZone.HasCards)
        {
            Ability.Source.AddGrantedAbility(new BlockerAbility());
        }
    }

    public override IContinuousEffect Copy()
    {
        return new BexTheOracleEffect(this);
    }
}
