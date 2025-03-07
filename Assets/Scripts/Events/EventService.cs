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
    public EventController OnPlusButtonClickedEvent { get; private set; }
    public EventController OnMinusButtonClickedEvent { get; private set; }
    public EventController<ItemModel> OnConfirmBuyButtonClickedEvent { get; private set; }
    public EventController<ItemModel> OnConfirmSellButtonClickedEvent { get; private set; }
    public EventController<ItemModel> OnBuyEvent { get; private set; }
    public EventController<ItemModel> OnSellEvent { get; private set; }
    public EventController<ItemModel> OnItemButtonClickedEvent { get; private set; }
    public EventController<ItemTypes> OnFilterButtonClickedEvent { get; private set; }
    
    public EventController<ItemsScriptableObject> OnBuyButtonClickedEvent { get; private set; }

    public EventService()
    {
        OnButtonAllClickedEvent = new EventController();
        OnFilterButtonClickedEvent = new EventController<ItemTypes>();
        OnBuyButtonClickedEvent = new EventController<ItemsScriptableObject>();
        OnItemButtonClickedEvent = new EventController<ItemModel>();
        OnPlusButtonClickedEvent = new EventController();
        OnMinusButtonClickedEvent = new EventController();
        OnConfirmBuyButtonClickedEvent = new EventController<ItemModel>();
        OnConfirmSellButtonClickedEvent = new EventController<ItemModel>();
        OnSellEvent = new EventController<ItemModel>();
        OnBuyEvent = new EventController<ItemModel>();
    }
}
