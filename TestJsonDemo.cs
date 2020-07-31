using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System;
using System.Collections.Generic;

namespace APISchemaValidation
{
    [TestClass]
    public class TestJsonDemo
    {

        [TestMethod]
        [Obsolete]
        public void TestThis()
        {
            string schemaJson = @"{
              'description': 'A person',
              'type': 'object',
              'properties': {
                'name': {'type':'string'},
                'hobbies': {
                  'type': 'array',
                  'items': {'type':'string'}
                }
               }
            }";

            JsonSchema schema = JsonSchema.Parse(schemaJson);

            JObject person = JObject.Parse(@"{
              'name': null,
              'hobbies': ['Invalid content', 0.123456789]
            }");

            IList<string> messages;
            bool valid = person.IsValid(schema, out messages);

            Console.WriteLine(valid);
            // false

            foreach (string message in messages)
            {
                PrintMessage("1.------------------>" + message);
            }
            // Invalid type. Expected String but got Null. Line 2, position 21.
            // Invalid type. Expected String but got Float. Line 3, position 51.
        }

        private void PrintMessage(String message)
        {
            System.Diagnostics.Debug.WriteLine(message);

        }

        [TestMethod]
        public void TestJSONSchemaGenerator()
        {
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(User));

            PrintMessage("2.--------------->" + schema.ToString());


            JObject user = JObject.Parse(@"{
                'email': 'abc@abc.com',
                'name': 'abc',
                'count': 1
            }");

            IList<string> messages;
            bool valid = user.IsValid(schema, out messages);

            Console.WriteLine(valid);
            // false

            foreach (string message in messages)
            {
                PrintMessage("1.------------------>" + message);
            }

        }


    }
}
