namespace Cake.Dart
{
    /// <summary>
    /// Common observatory settings
    /// </summary>
    public class ObservatorySettings
    {
        /// <summary>
        /// Enables observer
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public int? Port { get; set; }
        /// <summary>
        /// Bind address
        /// </summary>
        public string BindAddress { get; set; }
    }
}
