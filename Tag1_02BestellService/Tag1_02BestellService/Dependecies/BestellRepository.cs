using System;
using System.Collections.Generic;
using System.Text;

namespace Tag1_02BestellService.Dependecies
{
    public interface BestellRepository
    {
        void save(Bestellung bestellung);
        // ... weitere Methoden
    }
}
