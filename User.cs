using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISchemaValidation
{
    public class User
    {
        [JsonProperty("email", Required = Required.Always)]
        public String email;

        [JsonProperty("name", Required = Required.Always)]
        public String name;

        public int count;

    }
}
