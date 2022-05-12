﻿using IntegratorProject.src.data;
using IntegratorProject.src.dtos;
using IntegratorProject.src.repositories;
using IntegratorProject.src.repositories.implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratorProjectTest.Test.repositories
{
    [TestClass]
    public class KitRepositoryTest
    {
        private IntegratorProjectContext _context;
        private IKit _repository;

        [TestInitialize]
        public void InitialSettings()
        {
            var opt = new DbContextOptionsBuilder<IntegratorProjectContext>()
            .UseInMemoryDatabase(databaseName: "db_IntergratorProject")
            .Options;
            _context = new IntegratorProjectContext(opt);
            _repository = new KitRepository(_context);
        }
        [TestMethod]
        public void CreateNewKitReturnNameKitWhenSearchForName()
        {
            _repository.NewKit(
            new NewKitDTO("Kit Mulher", "Produtos basicos para mulher", 15, "27/04/2022"));
            _repository.NewKit(
            new NewKitDTO("Kit Higiene", "Produtos basicos para saúde", 35, "27/04/2022"));
            _repository.NewKit(
            new NewKitDTO("Kit Cesta Basica", "Produtos basicos para alimentação", 1000, "27/04/2022"));

            var kit = _repository.GetKitById(2);
            Assert.IsNotNull(kit);
            
        }
    }
}