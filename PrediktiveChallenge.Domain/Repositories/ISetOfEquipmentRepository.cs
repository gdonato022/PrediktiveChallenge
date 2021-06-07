using System.Collections.Generic;

namespace PrediktiveChallenge.Domain.Repositories
{
    public interface ISetOfEquipmentRepository
    {
        Dictionary<string, SetOfEquipmentItem> GetAllSetsOfEquipment();
    }
}
