//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Windows.Networking.Connectivity;
//
//namespace YT_DLP.player
//{
//    internal class NetworkHelper
//    {
//        public static bool IsConnectedToMeteredNetwork()
//        {
//            var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
//
//            if (connectionProfile == null)
//                return false; // No connection
//
//            var cost = connectionProfile.GetConnectionCost();
//
//            return cost.NetworkCostType == NetworkCostType.Fixed ||
//                   cost.NetworkCostType == NetworkCostType.Variable;
//        }
//    }
//}
//