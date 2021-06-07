using PrediktiveChallenge.Application.Interfaces;
using PrediktiveChallenge.Domain;
using PrediktiveChallenge.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrediktiveChallenge.Application.Apps
{
    public class SetOfEquipmentApplication : ISetOfEquipmentApplication
    {
        private readonly ISetOfEquipmentRepository _setOfEquipmentRepository;

        public SetOfEquipmentApplication(ISetOfEquipmentRepository setOfEquipmentRepository)
        {
            _setOfEquipmentRepository = setOfEquipmentRepository;
        }
        public CalculatedValues GetCalculatedValues(string id, string year)
        {
            var item = FindById(id);

            var cost = item.SaleDetails.Cost;
            var marketRatio = item.Schedule.YearItems[year].MarketRatio;
            var auctionRatio = item.Schedule.YearItems[year].AuctionRatio;

            var marketValue = cost * marketRatio;
            var auctionValue = cost * auctionRatio;

            return new CalculatedValues { MarketValue = marketValue, AuctionValue = auctionValue };
        }

        private SetOfEquipmentItem FindById(string id)
        {
            var allSets = _setOfEquipmentRepository.GetAllSetsOfEquipment();

            if (string.IsNullOrWhiteSpace(id) || !allSets.ContainsKey(id))
                throw new Exception("Invalid Id");

            return allSets[id];
        }
    }
}
