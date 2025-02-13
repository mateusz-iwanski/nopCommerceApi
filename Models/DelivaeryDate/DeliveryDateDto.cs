namespace nopCommerceApi.Models.DelivaeryDate
{
    public class DeliveryDateDto : BaseDto
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; } = null!;
        public virtual int DisplayOrder { get; set; }
    }
}
