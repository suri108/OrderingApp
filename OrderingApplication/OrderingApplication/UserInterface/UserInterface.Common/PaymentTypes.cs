using System.Collections.Generic;

namespace UserInterface.Common
{
    public static class PaymentTypes
    {
        public static List<SelectListItem> GetTypes() => new List<string>{
            "Physical product",
            "Book",
            "Membership",
            "Upgrade",
            "Learning to Ski video"
        };
    }
}