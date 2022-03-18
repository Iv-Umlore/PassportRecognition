using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class MongoDataModel
    {
        public string DocNumber { get; set; }

        public string PersonName { get; set; }

        public ExternalObjectModel DocInfo { get; set; }

        public byte[] Image { get; set; }
    }
}
