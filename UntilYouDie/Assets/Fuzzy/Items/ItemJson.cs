using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sirenix.Serialization;

namespace Fuzzy.Entities
{
    public class ItemJson
    {
        public static int GetNextID() {
            int ret = 0;

            var a = new DeserializationContext();
            using (Stream file = new FileStream("", FileMode.Open))
            using (JsonDataReader reader = new JsonDataReader(file, a)) {
                //bool bOk = reader.ReadInt32(out ret);

                //increment the value by 1.
                //store the incremented value in the file.
                //save file.
            }

            return ret;
        }
    }
}
