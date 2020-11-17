using System;
using System.Collections.Generic;
using System.Text;

namespace Tag1_02BestellService.Dependecies
{
    public interface SolvenzService
    {
        bool checkSolvenz(string creditCardType /* Master oder Visa */, string creditCardNumber /* 10 genau 10 numerische Stellen */, double saldo);  // Löst potenziell eine Exception aus
    }
}
