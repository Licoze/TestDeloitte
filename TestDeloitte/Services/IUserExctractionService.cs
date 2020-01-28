using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeloitte.Services
{
    public interface IModelExtractionService<T>
    {
        public T ExctractModelFromFile();
    }
}
