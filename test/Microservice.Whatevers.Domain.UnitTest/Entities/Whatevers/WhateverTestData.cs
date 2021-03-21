using System;

namespace Microservice.Whatevers.Domain.UnitTest.Entities.Whatevers
{
    public abstract class WhateverTestData
    {
        protected const string Name = "Name";
        protected const string Type = "Type";
        protected readonly Guid Id = Guid.NewGuid();
        protected readonly DateTime Time = DateTime.Now;
    }
}