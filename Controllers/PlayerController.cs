using System.Collections.Generic;
using APIApplication.Data;
using APIApplication.Dtos;
using APIApplication.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace APIApplication.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepo _repository;
        private readonly IMapper _mapper;

       

        public PlayerController(IPlayerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/players
        [HttpGet]
        public ActionResult<IEnumerable<PlayerReadDto>> GetAllPlayers()
        {
            var playerItems = _repository.GetAllPlayers();

            return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(playerItems));
        }

        //GET api/players/{id}
        [HttpGet("{id}", Name = "GetPlayerbyId" )]
        public ActionResult<PlayerReadDto> GetPlayerbyId(int id)
        {
            var playerItem = _repository.GetPlayerById(id);
            if (playerItem != null)
            {
                return Ok(_mapper.Map<PlayerReadDto>(playerItem));
            }
            return NotFound();
        }

        //POST api/players
        [HttpPost]
        public ActionResult<PlayerReadDto> CreatePlayer(PlayerCreateDto playerCreateDto)
        {
            var playerModel = _mapper.Map<Players>(playerCreateDto);
            _repository.CreatePlayer(playerModel);
            _repository.SaveChanges();

            var playerReadDto = _mapper.Map<PlayerReadDto>(playerModel);

            return CreatedAtRoute(nameof(GetPlayerbyId), new { Id = playerReadDto.Id }, playerReadDto);
        }

        //PUT api/players/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePlayer(int id, PlayerUpdateDto playerUpdateDto)
        {
            var playerModelFromRepo = _repository.GetPlayerById(id);
            if (playerModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(playerUpdateDto, playerModelFromRepo);

            _repository.UpdatePlayer(playerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/players/{id}
        [HttpPatch]
        public ActionResult PartialPlayerUpdate(int id, JsonPatchDocument<PlayerUpdateDto> patchDoc)
        {
            var playerModelFromRepo = _repository.GetPlayerById(id);
            if (playerModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<PlayerUpdateDto>(playerModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, playerModelFromRepo);

            _repository.UpdatePlayer(playerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        //DELETE api/players/id
        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(int id)
        {
            var playerModelFromRepo = _repository.GetPlayerById(id);
            if (playerModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeletePlayer(playerModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }




    }
}
