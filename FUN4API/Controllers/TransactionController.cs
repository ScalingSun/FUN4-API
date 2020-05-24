using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EFLibrary;
using FUN4API.Model;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FUN4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        public DataContext _Db { get; }
        public TransactionController(IConfiguration config, DataContext db)
        {
            _Db = db;
        }
        /// <summary>
        /// This is to get all transactions per user.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int Id)
        {
            CRUDTransaction transaction = new CRUDTransaction(_Db);
            var alluserdata = transaction.GetByUserId(Id);
            var result = JsonSerializer.Serialize(alluserdata);
            return result;
        }

        [HttpPost("")]
        public string Add([FromBody] TransactionModel data)
        {
            CRUDTransaction CRUD = new CRUDTransaction(_Db);            
            CRUD.Add(data);
            return "new transaction has been added.";
        }

        /// <summary>
        /// This is to get all transactions SUBMITTED by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("SubmittedBy/{id}")]
        public string GetAllBySubmittedId(int Id)
        {
            CRUDTransaction transaction = new CRUDTransaction(_Db);
            var alluserdata = transaction.GetByUserSubmittedId(Id);
            return JsonSerializer.Serialize(alluserdata);
        }
        [HttpGet("")]
        public string GetAll()
        {
            CRUDTransaction crud = new CRUDTransaction(_Db);
            return JsonSerializer.Serialize(crud.GetAll<Transaction>());
        }
        [HttpPost("multiple")]
        public string AddMultiple([FromBody] List<TransactionModel> data)
        {
            List<TransactionModel> result = new List<TransactionModel>();
            foreach (TransactionModel model in data)
            {
                if (model.Id != 0 || model.Amount != 0)
                {
                    result.Add(model);
                }
            }
            CRUDTransaction crud = new CRUDTransaction(_Db);
            crud.AddMultiple(result);
            return "Transactions have been added.";
        }
    }
}