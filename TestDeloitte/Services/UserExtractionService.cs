using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestDeloitte.Models;

namespace TestDeloitte.Services
{
    public class ModelExtractionService<T> : IModelExtractionService<T> where T : class
    {
        private string _filename;
        public ModelExtractionService(string filename) {
            _filename = filename;
        }
        public T ExctractModelFromFile()
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(Directory.GetCurrentDirectory() + _filename));
        }
    }
}

