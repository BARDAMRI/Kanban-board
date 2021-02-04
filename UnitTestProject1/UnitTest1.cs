using System;
using NUnit.Framework;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UnitTestProject1
{

    public class UnitTest1
    {
        Service service;
        Service service2;

        [SetUp]
        public void setup()
        {
            service = new Service();
            
        }
        [Test]
        public void register()
        {
            service.Register("cfmlvcvnx@bgu.ac.il", "Bar1702", "bar");
        }
        [Test]
        public void addTask()
        {
            service.Register("cfmlvcvnx@bgu.ac.il", "Bar1702", "bar");
            service.DeleteData();
        }
    }
}
