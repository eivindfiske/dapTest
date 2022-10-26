using Microsoft.EntityFrameworkCore;
using dapTest.Data;
using Microsoft.Data.SqlClient;

namespace dapTest
{
    public class Gruppe11
    {
        public int id { get; set; }
        public string navn { get; set; } = string.Empty;

        public string etternavn { get; set; } = string.Empty;

    }
}
