using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrediktiveChallenge.Application.Apps;
using PrediktiveChallenge.Application.Interfaces;
using PrediktiveChallenge.Infrastructure.Repositories;
using System;
using FluentAssertions;

namespace PrediktiveChallenge.Tests.Applications
{
    [TestClass]
    public class SetOfEquipmentApplicationTest
    {
        private ISetOfEquipmentApplication _setOfEquipmentApplication;

        [TestInitialize()]
        public void Initialize()
        {
            _setOfEquipmentApplication = new SetOfEquipmentApplication(new SetOfEquipmentRepository());
        }

        [TestMethod]
        public void GetCalculatedValues_2007_67352()
        {
            var result = _setOfEquipmentApplication.GetCalculatedValues("67352", "2007");

            result.Should().NotBeNull();
        }

        [TestMethod]
        public void GetCalculatedValues_2011_87964_Error()
        {
            Action act = () => _setOfEquipmentApplication.GetCalculatedValues("87964", "2011");

            act.Should().Throw<Exception>();
        }
    }
}
