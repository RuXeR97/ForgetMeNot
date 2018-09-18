using System;

namespace CommonComponents
{
    public static class EventHelpers
    {
        public static void RaiseEvent(Object objectRaisingEvent,
                                      EventHandler<AccessTypeEventArgs> eventHandlerRaised,
                                      AccessTypeEventArgs accessTypeEventArgs)
        {
            if (eventHandlerRaised != null) //Check if any subscribed to this event 
            {
                eventHandlerRaised(objectRaisingEvent, accessTypeEventArgs); // Notify all subscribers 
            }
        }

        public static void RaiseEvent(Object objectRaisingEvent, EventHandler eventHandlerRaised, EventArgs eventArgs)
        {
            if (eventHandlerRaised != null) //Check if any subscribed to this event 
            {
                eventHandlerRaised(objectRaisingEvent, eventArgs); // Notify all subscribers
            }
        }
    }
}
