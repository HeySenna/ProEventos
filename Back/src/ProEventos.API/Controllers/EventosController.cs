using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;

namespace ProEventos.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class EventosController : ControllerBase
   {
      private readonly IEventoService _eventoService;
      public EventosController(IEventoService eventoService)
      {
         _eventoService = eventoService;
      }

      [HttpGet]
      public async Task<IActionResult> Get()
      {
         try
         {
            var eventos = await _eventoService.GetAllEventosAsync(true);
            if(eventos == null)
               return NoContent();

            return Ok(eventos);
         }
         catch (Exception e)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar recuperar eventos. Erro: {e.Message}");
         }
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetById(int id)
      {
         try
         {
            var evento = await _eventoService.GetEventoByIdAsync(id);
            if(evento == null)
               return NoContent();
            
            return Ok(evento);
         }
         catch (Exception e)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar recuperar evento. Erro: {e.Message}");
         }
      }
      
      [HttpGet("{tema}/tema")]
      public async Task<IActionResult> GetByTema(string tema)
      {
         try
         {
            var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if(eventos == null)
               return NoContent();
            
            return Ok(eventos);
         }
         catch (Exception e)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar recuperar evento. Erro: {e.Message}");
         }
      }

      [HttpPost]
      public async Task<IActionResult> Post(EventoDto model)
      {
         try
         {
            var evento = await _eventoService.AddEventos(model);
            if(evento == null)
               return NoContent();
            
            return Ok(evento);
         }
         catch (Exception e)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar adicionar evento. Erro: {e.Message}");
         }
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, EventoDto model)
      {
         try
         {
            var evento = await _eventoService.UpdateEvento(id, model);
            if(evento == null)
               return NoContent();
            
            return Ok(evento);
         }
         catch (Exception e)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar atualizar evento. Erro: {e.Message}");
         }
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         try
         { 
            return await _eventoService.DeleteEvento(id)
               ?  Ok("Deletado")
               : BadRequest("Evento não deletado.");
         }
         catch (Exception e)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar recuperar evento. Erro: {e.Message}");
         }
      }
   }
}