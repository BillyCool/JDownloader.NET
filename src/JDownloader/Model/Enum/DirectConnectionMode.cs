namespace JDownloader.Model.Enum
{
    public enum DirectConnectionMode
    {
        NONE, // Disable direct connections
        LAN, // Only allow direct connections from LAN
        LAN_WAN_MANUAL, // Allow LAN/WAN connections with manual port forwarding
        LAN_WAN_UPNP // Allow LAN/WAN connections with automatic port forwarding via UPNP
    }
}
