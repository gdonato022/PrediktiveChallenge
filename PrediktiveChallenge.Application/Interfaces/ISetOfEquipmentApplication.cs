using PrediktiveChallenge.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrediktiveChallenge.Application.Interfaces
{
    public interface ISetOfEquipmentApplication
    {
        CalculatedValues GetCalculatedValues(string id, string year);
    }
}
