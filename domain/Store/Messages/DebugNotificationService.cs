using System.Diagnostics;

namespace Store.Messages
{
    public   class DebugNotificationService : INotificationService
    {
        public void SendConfirmationCode(string cellPhone, int code)
        {
            Debug.WriteLine("Номер телефона: {0}, код: {1:0000}.", cellPhone, code);
        }
    }
}
