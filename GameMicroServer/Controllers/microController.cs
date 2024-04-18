using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using GameMicroServer.Services;

namespace Micro
{
    [ApiController]
    [Route("[controller]")]
    public class MicroController : ControllerBase
    {
        /// <summary>
        /// This is an editted version of the original monolithic microservice to only contain the Tetris object inside the array.
        /// Instead of reconfiguring the architecture to instead only pass one object it is more efficient to keep the same structure and return a one item list since we are'nt worried about
        /// peak performance at this moment.
        /// </summary>
        private static readonly List<GameInfo> TheInfo = new List<GameInfo>
        {
            new GameInfo {
                Id = 3,
                Title = "Pong",
                //Content = "~/js/pong.js",
                Author = "Forest Gump",
                DateAdded = "07/04/1742",
                Description = "RUN FOREST RUN!",
                HowTo = "Hit the back back",
                //Thumbnail = "/images/pong.jpg"
            },

        };

        private readonly ILogger<MicroController> _logger;

        public MicroController(ILogger<MicroController> logger)
        {
            _logger = logger;
        }

        private readonly IGameRepository _gameRepo;
        //public MicroController(IGameRepository gameRepo)
        //{
        //    _gameRepo = gameRepo;
        //}

        //[HttpGet("game/{id}")]
        //public IActionResult Get(int id)
        //{
        //    var game = _gameRepo.GetByIdAsync(id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(game);
        //}
        // This method will return the GameInfo object with the specified ID

        [HttpGet]
        public IEnumerable<GameInfo> Get()
        {
            return TheInfo;
        }
    }
}
