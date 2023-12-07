namespace Poultry.Domain.Entities
{
    public class Weather : BaseEntity
    {

        public long ZoneId { get; set; }
        public Zone Zone { get; set; }

    }
}
