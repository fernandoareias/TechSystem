using System;
using System.Collections.Generic;

namespace TechSystem.Domain.Queries
{
    public class ListEmployeeQueryResults
    {

        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Wage { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
    }
}