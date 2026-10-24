namespace Interfaces.ContinuousEffects
{
    public interface IPlayerCannotTapCreatureEffect : IContinuousEffect
    {
        bool PlayerCannotTapCreature(IPlayerV2 player, ICreature creature, IGame game);
    }
}
