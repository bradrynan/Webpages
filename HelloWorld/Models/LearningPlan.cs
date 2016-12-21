using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class LearningPlan
    {
        public int ID { get; set; }

        public string LearningType { get; set; }

        public string Description { get; set; }

        public LearningPlan LearningPlanParentID { get; set; }
    }
}