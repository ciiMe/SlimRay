using System.Collections.Generic;

namespace SlimRay
{
    public class ServicePool<T>  
    {
        public enum ServicePoolWorkMode
        {
            /// <summary>
            /// Only 1 service item can be active,
            /// it provides service for calling.
            /// </summary>
            SingleProvider,
            /// <summary>
            /// All service item are active,but only one item provide the service.
            /// Pool will call all items one by one until an item returns true,
            /// true means it has provided the service successfully,
            /// and then pool would stop calling other items.
            /// </summary>
            TryUntillOK,
            /// <summary>
            /// All service item are active,
            /// pool will call them one by one,it does not care item's
            /// service providing is successful or not.
            /// </summary>
            TryAll
        }

        protected static List<T> _services = new List<T>();
        protected static T _activeService = default(T);
        private static ServicePoolWorkMode _mode = ServicePoolWorkMode.SingleProvider;

        public static T ActiveService
        {
            get { return _activeService; }
        }

        /// <summary>
        /// Only single active is valid now,
        /// so,the property is get only.
        /// </summary>
        public static ServicePoolWorkMode Mode
        {
            get { return _mode; }
            //set { _mode = value; }
        }

        /// <summary>
        /// Register service,set active when it is the first.
        /// </summary>
        /// <param name="service"></param>
        public static void Register(T service)
        {
            if (Exists(service))
            {
                return;
            }

            _services.Add(service);

            if (_services.Count == 1)
            {
                _activeService = service;
            }
        }

        /// <summary>
        /// Unregister the service and set first service active.
        /// </summary>
        /// <param name="service"></param>
        public static void Unregister(T service)
        {
            if (!Exists(service))
            {
                return;
            }
            _services.Remove(service);

            if (_services.Count == 0)
            {
                _activeService = default(T);
                return;
            }

            if (_activeService.Equals(service))
            {
                _activeService = _services[0];
            }
        }

        public static bool Active(T service)
        {
            if (!Exists(service))
            {
                return false;
            }

            _activeService = service;
            return true;
        }

        public static bool Active(int index)
        {
            if (index < 0 || index >= _services.Count)
            {
                return false;
            }

            _activeService = _services[index];
            return true;
        }

        private static bool Exists(T service)
        {
            int i = _services.IndexOf(service);

            return i >= 0 && i < _services.Count;
        }
    }
}
