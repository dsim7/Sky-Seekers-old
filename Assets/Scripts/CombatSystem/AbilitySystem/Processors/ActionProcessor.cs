

public abstract class ActionProcessor<T>
{
    public abstract void ProcessStartEvents(T instance);

    public abstract void ProcessCompleteEvents(T instance);
}
