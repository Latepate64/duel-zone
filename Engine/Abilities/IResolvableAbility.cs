namespace Engine.Abilities
{
    public interface IResolvableAbility : IAbility
    {
        void Resolve(IGame game);
    }
}