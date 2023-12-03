using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Stok
{
    public record tblSubContractorDto
    {
        public int Id { get; init; }
        public String Name { get; init; }
    }
}
