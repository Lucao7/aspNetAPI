using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Corretoras;
using Model.General;
using Business.Corretoras;

namespace WebApiNfe.Controllers
{
    public class CorretorasController : ControllerBase
    {
        private readonly IBCorretora _bCorretora;

        /// <summary>
        /// Construtor        
        /// </summary>
        public CorretorasController(IBCorretora bCorretora)
        {
            _bCorretora = bCorretora;
        }

        /// <summary>
        /// GET: api/Corretoras        
        /// </summary>        
        [HttpGet("Corretoras")]
        public async Task<ICollection<Corretora>> Get(BasePagination pagination)
        {
            pagination.Count = _bCorretora.GetListAllCount(x => true).Result;


            return await _bCorretora.GetListAll(x => true);
        }

        /// <summary>
        /// GET: api/Corretoras/5
        /// </summary>
        /// <param name="corretoraId">Id da corretora</param>        
        [HttpGet("Corretoras/id")]
        public async Task<Corretora> GetCorretora(int corretoraId)
        {
            var corretora = await _bCorretora.Get(corretoraId);

            if (corretora == null)
            {
                return null;
            }

            return corretora;
        }

        /// <summary>
        /// PUT: api/Corretoras/5
        /// </summary>
        /// <param name="corretoraId">Id da corretora</param>
        /// <param name="corretora">Corretora</param>
        [HttpPut("Corretoras/{corretoraId}")]
        public async Task<Corretora> PutCorretora(int corretoraId, Corretora corretora)
        {
            if (corretoraId != corretora.CorretoraId)
            {
                return null;
            }

            await _bCorretora.Update(corretora);

            return corretora;
        }

        /// <summary>
        /// POST: api/Corretoras
        /// </summary>
        /// <param name="corretora">Corretora</param>
        [HttpPost("corretora")]
        public async Task<Corretora> Post(Corretora corretora)
        {
            await _bCorretora.Add(corretora);

            return corretora;
        }

        /// <summary>
        /// DELETE: api/Corretoras/5
        /// </summary>
        /// <param name="corretoraId">Id Corretora</param>
        [HttpDelete("Corretoras/corretoraId")]
        public async Task<Corretora> DeleteCorretora(int corretoraId)
        {
            var corretora = await _bCorretora.Get(corretoraId);
            if (corretora == null)
            {
                return null;
            }

            await _bCorretora.Delete(x => x.CorretoraId == corretoraId);

            return corretora;
        }
    }
}
