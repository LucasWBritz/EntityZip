using EntityZip.Attributes;
using System.Collections.Generic;

namespace EntityZipConsole.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [ExportProperty]
        public string FirstName { get; set; }

        [ExportProperty]
        public string LastName { get; set; }

        [ExportProperty]
        public string Email { get; set; }
        
        public bool Active { get; set; }
        
        public IEnumerable<Address> Addresses { get; set; }
    }
}
