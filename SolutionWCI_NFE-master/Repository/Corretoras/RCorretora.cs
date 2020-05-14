using Context;
using Model.Corretoras;
using Repository.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Corretoras
{
    public class RCorretora : Repository<Corretora>
    {
        public RCorretora(SolutionContext context) : base(context)
        {

        }
    }
}
