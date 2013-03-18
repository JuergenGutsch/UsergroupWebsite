﻿using System.Web.Mvc;
﻿using CommunitySite.Web.App_Start;
﻿using CommunitySite.Web.Data;
﻿using NUnit.Framework;
using Subtext.TestLibrary;

namespace CommunitySite.Tests
{
    [TestFixture]
    public class Wenn_UnitOfWork_is_resolved
    {
        private HttpSimulator _httpSimulator;

        [SetUp]
        public void Setup()
        {
            _httpSimulator = new HttpSimulator().SimulateRequest();
        }

        [TearDown]
        public void Teardown()
        {
            _httpSimulator.Dispose();
        }

        [Test]
        public void it_schould_not_be_Null()
        {
            // IocConfig.RegisterDependencies();
            NinjectWebCommon.Start();

            var unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();

            Assert.That(unitOfWork, Is.Not.Null);
        }

        [Test]
        public void its_Events_schould_not_be_Null()
        {
            // IocConfig.RegisterDependencies();
            NinjectWebCommon.Start();

            var unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();

            Assert.That(unitOfWork.Events, Is.Not.Null);
        }
    }
}