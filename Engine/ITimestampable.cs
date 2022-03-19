namespace Engine
{
    /// <summary>
    /// 613.7. Within a layer or sublayer, determining which order effects are applied in is usually done using a timestamp system.
    /// An effect with an earlier timestamp is applied before an effect with a later timestamp.
    /// </summary>
    public interface ITimestampable
    {
        /// <summary>
        /// 613.7. Within a layer or sublayer, determining which order effects are applied in is usually done using a timestamp system.
        /// An effect with an earlier timestamp is applied before an effect with a later timestamp.
        /// </summary>
        public int Timestamp { get; set; }
    }
}
