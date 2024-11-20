using Microsoft.EntityFrameworkCore;

namespace CountryApp_Cloud
{
    public class CountryEntity
    {
        public int id { get; set; }
        public string fullName { get; set; } = string.Empty;
        public string shortName { get; set; } = string.Empty;
        
        //[Index(IsUnique = true)]
        public string alpha2Code { get; set; } = Guid.NewGuid().ToString();
        public CountryEntity() { } //конструктор по умолчанию
    }
}
