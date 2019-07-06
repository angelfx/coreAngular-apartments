using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Abstract.Logic
{
    public interface IApartmentsImport
    {
        string Import(string path, char separator);
    }
}
