using System;

namespace CommonComponents
{
    public class EventHelpers
    {
        public static void RaiseEvent(Object objectRaisingEvent,
            EventHandler<AccessTypeEventArgs> eventHandlerRaised,
            AccessTypeEventArgs accessTypeEventArgs)
        {
            // we check if anyone subscribed for the event
            if (eventHandlerRaised != null)
            {
                eventHandlerRaised(objectRaisingEvent, accessTypeEventArgs); // notifies subscribers
            }
        }

        public static void RaiseEvent(Object objectRaisingEvent,
            EventHandler eventHandlerRaised,
            EventArgs accessTypeEventArgs)
        {
            // we check if anyone subscribed for the event
            if (eventHandlerRaised != null)
            {
                eventHandlerRaised(objectRaisingEvent, accessTypeEventArgs); // notifies subscribers
            }
        }
    }
}
