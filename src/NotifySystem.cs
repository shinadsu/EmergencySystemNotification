using EmergencySystemNotification.src.INotiication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencySystemNotification.src
{
    internal class NotifySystem : InotificationSystem
    {
        private string _message;

        public delegate Task NotificationMessage(string message);
        public event NotificationMessage notify;

        public NotifySystem(string message)
        {
            _message = message;
        }

        public void Notify()
        {
            if (_message == null)
                throw new ArgumentNullException(nameof(_message));

            notify?.Invoke(_message);
        }
    }
}
