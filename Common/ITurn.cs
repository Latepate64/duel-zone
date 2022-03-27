namespace Common
{
    public interface ITurn : IIdentifiable
    {
        
        int Number { get; set; }

        System.Guid ActivePlayerId { get; set; }

        string ToString();
    }
}