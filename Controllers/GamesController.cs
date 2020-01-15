using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Games;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGameService _gameService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public GamesController( IGameService gameService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _gameService = gameService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var games = _gameService.GetAll();
            var model = _mapper.Map<IList<GameModel>>(games);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var game = _gameService.GetById(id);
            var model = _mapper.Map<GameModel>(game);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]GameUpdateModel model)
        {
            //Map to entity
            var game = _mapper.Map<Game>(model);
            game.Id = id;
            
            try
            {
                //Update game
                _gameService.Update(game);
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
            _gameService.Delete(id);
            return Ok();
        }

        [HttpPost("NewGame")]
        public IActionResult NewGame ([FromBody]GameInsertModel model)
        {
            var game = _mapper.Map<Game>(model);

            //Inserting new game
            try
            {
                _gameService.Create(game, model.Title);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}



