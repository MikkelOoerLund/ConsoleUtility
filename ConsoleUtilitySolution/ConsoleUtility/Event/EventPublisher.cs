namespace ConsoleUtility
{
    public class EventPublisher<T>
    {
        private List<IEventListener<T>> _events;

        public EventPublisher(List<IEventListener<T>> events)
        {
            if (events == null)
            {
                throw new Exception();
            }

            _events = events;
        }


        public void AddEvent(IEventListener<T> @event)
        {
            _events.Add(@event);
        }

        public void RemoveEvent(IEventListener<T> @event)
        {
            _events.Remove(@event);
        }

        public void Publish(T data)
        {
            foreach (var @event in _events)
            {
                @event.OnInvoke(data);
            }
        }
    }
}