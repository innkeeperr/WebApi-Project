using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Opinions;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private IOpinionService _opinionService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public OpinionController(IOpinionService opinionService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _opinionService = opinionService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var opinions = _opinionService.GetAll();
            var model = _mapper.Map<IList<OpinionModel>>(opinions);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]OpinionModel model)
        {
            var opinion = _mapper.Map<Opinion>(model);
            opinion.Id = id;

            try
            {
                //Update opinion
                _opinionService.Update(opinion);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _opinionService.Delete(id);
            return Ok();
        }

        [HttpPost("CreateOpinion")]
        public IActionResult NewOpinion ([FromBody]OpinionInsertModel model)
        {
            var opinion = _mapper.Map<Opinion>(model);

            //Creating new review
            try
            {
                _opinionService.Create(opinion);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetByGameId")]
        public IActionResult GetOpinionByGameId([FromQuery] int id=0)
        {
            var opinions = _opinionService.GetByGameId(id);
            var model = _mapper.Map<IList<OpinionModel>>(opinions);
            return Ok(model);
        }
    }
}