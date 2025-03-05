using UnityEngine;

public class EventService 
{
    private static EventService instance;

    public static EventService Instance
    {
        get
        {
            if (instance == null)

            {
                instance = new EventService();
            }
            return instance;
        }
    }
    
    public EventController OnButtonAllClickedEvent { get; private set; }
    public EventController<ItemTypes> OnFilterButtonClickedEvent { get; private set; }

    public EventService()
    {
        OnButtonAllClickedEvent = new EventController();
        OnFilterButtonClickedEvent = new EventController<ItemTypes>();
    }
}
