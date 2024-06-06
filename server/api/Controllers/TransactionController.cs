using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController(FirestoreService firestoreService) : ControllerBase
    {
        private readonly FirestoreService _firestoreService = firestoreService;

        [HttpPost]
        public async Task<ActionResult<UserTransaction>> Create(UserTransaction userTransaction)
        {
            try
            {
                await _firestoreService.AddDocumentAsync(userTransaction);

                return Ok();
            } catch(Exception ex)
            {
                // todo handle better errors
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<UserTransaction>> GetAll()
        {
            try
            {
                var transactions = await _firestoreService.GetAllDocumentsAsync<UserTransaction>();

                return Ok(transactions);
            } catch(Exception ex)
            {
                // todo handle better errors
                return BadRequest(ex.Message);
            }
        }
    }
}
