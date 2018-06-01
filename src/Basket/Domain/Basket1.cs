﻿using System;
using System.Collections.Generic;

namespace Basket.Domain
{
    public class Basket1
    {
        private readonly IList<BasketLine> _basketLines;

        public Basket1(IList<BasketLine> basketLines)
        {
            _basketLines = basketLines;
        }

        public int Calculate()
        {
            var total = 0;
            foreach (var basketLine in _basketLines)
            {
                total += basketLine.Calculate();
            }

            return total;
        }
    }
}