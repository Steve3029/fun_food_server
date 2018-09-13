﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FunFoodServer.Domain.Model
{
    public class Recipe : AggregateRoot
    {
      public string Title { set; get; }

      public string BriefDesc { set; get; }

      public Category Category { set; get; }

      public string Description { get; set; }

      public string CoverImageUrl { get; set; }

      public int Serving { get; set; }

      public List<Ingredient> Ingredients { get; set; }

      public List<Instruction> Instructions { get; set; }

      public User Author { get; set; }
    }
}
