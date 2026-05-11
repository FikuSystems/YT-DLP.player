using Windows.Networking.Connectivity;

namespace YT_DLP.player
{
    public static class NetworkHelper
    {
        public static bool IsConnectedToMeteredNetwork()
        {
            try
            {
                var profile = NetworkInformation.GetInternetConnectionProfile();
                if (profile == null)
                    return false;

                var cost = profile.GetConnectionCost();
                return cost.NetworkCostType != NetworkCostType.Unrestricted;
            }
            catch
            {
                // In case of any issues accessing network information, default to false
                return false;
            }
        }
    }
}
