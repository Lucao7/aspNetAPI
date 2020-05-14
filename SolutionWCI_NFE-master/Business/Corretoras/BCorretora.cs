using Business.General;
using Context;
using Model.Corretoras;
using Repository.Corretoras;
using Repository.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Corretoras
{
    public class BCorretora : BRepository<Corretora>
    {
        public BCorretora(SolutionContext context)
            : base(new RCorretora(context))
        {

        }

        public interface IBCorretora : IRepository<Corretora>
        {

        }
    }
}
