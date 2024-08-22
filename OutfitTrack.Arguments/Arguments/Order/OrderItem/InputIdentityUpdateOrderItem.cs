namespace OutfitTrack.Arguments.Arguments;

public class InputIdentityUpdateOrderItem
{
    public long? Id { get; set; }
    public InputUpdateOrderItem? InputUpdate { get; set; }

    public InputIdentityUpdateOrderItem() { }

    public InputIdentityUpdateOrderItem(long id, InputUpdateOrderItem inputUpdate)
    {
        Id = id;
        InputUpdate = inputUpdate;
    }
}