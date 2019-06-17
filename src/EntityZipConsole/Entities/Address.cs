using EntityZip.Attributes;

namespace EntityZipConsole.Entities
{
    public class Address
    {
        [ExportProperty]
        public string Street { get; set; }

        [ExportProperty]
        public string City { get; set; }

        [ExportProperty]
        public string PostalCode { get; set; }

        [ExportProperty]
        public string Country { get; set; }
        public bool MainAddress { get; set; } // I'm ignoring this property
    }
}
