using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FirstWebApiApp.Data.Interfaces;
using FirstWebApiApp.Data.Repository;
using FirstWebApiApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApiApp.Controllers
{
    [Route("items")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        public readonly static IToDoRepository toDoRepository = new ToDoRepository();

        #region GET CALLS
        #region GET ALL ITEMS
        [HttpGet("get/all")]
        public async Task<ActionResult> getAllToDoItems()
        {
            try
            {
                List<ToDoItem> reponse_repo = await toDoRepository.getAllItems();
                return new ObjectResult(new { message = "success", statusCode = HttpStatusCode.OK, response = reponse_repo });
            }
            catch(Exception ex)
            {
                return new NotFoundObjectResult(new { message = ex.Message, statusCode = HttpStatusCode.InternalServerError });
            }
        }
        #endregion

        #region GET ITEM BY ID
        [HttpGet("get/by/{id}")]
        public async Task<IActionResult> getToDoItemById(int id)
        {
            try
            {

                ToDoItem response_repo = await toDoRepository.getItemById(id);
              
                return new ObjectResult(new { message = "success", statusCode = HttpStatusCode.OK, response = response_repo });
            }
            catch(Exception ex)
            {
                return new NotFoundObjectResult(new { message = ex.Message, statusCode = HttpStatusCode.InternalServerError });
            }
          
        }

        #endregion

        #endregion

        #region POST CALLS 

        #region CREATE NEW ITEM
        [HttpPost("create")]
        public async Task<IActionResult> createNewItem([FromBody] ToDoItem toDoItem)
        {
            try
            {
                if (toDoItem == null)
                {
                    return new NotFoundObjectResult(new { message = "To do item is null", statusCode = HttpStatusCode.InternalServerError });
                }
                string reponse_repo = await toDoRepository.createNewItem(toDoItem);
                return new ObjectResult(reponse_repo);
            }
            catch (Exception ex)
            {
                return new NotFoundObjectResult(new { message = ex.Message, statusCode = HttpStatusCode.InternalServerError });
            }
        }
        #endregion


        #endregion

        #region PUT CALLS
        [HttpPut("update/{id}")]
        public async Task<IActionResult> updateItem([FromBody] ToDoItem toDoItem, int id)
        {
            try
            {
                if (toDoItem == null)
                {
                    return new NotFoundObjectResult(new { message = "To do item is null", statusCode = HttpStatusCode.InternalServerError });
                }
                string response_repo = await toDoRepository.updateItem(toDoItem, id);
                return new ObjectResult(new { message = "success", statusCode = HttpStatusCode.OK, response =response_repo });
            }
            catch (Exception ex)
            {
                return new NotFoundObjectResult(new { message = ex.Message, statusCode = HttpStatusCode.InternalServerError });
            }
        }
        #endregion

        #region DELETE CALL  
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> deleteItem(int id)
        {
            try
            {
                string response_repo = await toDoRepository.deleteItem(id);
                return new ObjectResult(new { message = "success", statusCode = HttpStatusCode.OK, response = response_repo });
            }
            catch (Exception ex)
            {
                return new NotFoundObjectResult(new { message = ex.Message, statusCode = HttpStatusCode.InternalServerError });
            }
        }
        #endregion
    }
}