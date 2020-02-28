using API.Core.Interfaces;
using API.Entities.Entities;
using API.Entities.Response;
using API.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace API.Core.UseCases
{
    public class ReceiptManager : IDataRepository<Receipt>
    {
        readonly DataContext _employeeContext;

        public ReceiptManager(DataContext context)
        {
            _employeeContext = context;
        }

        public IEnumerable<Receipt> GetAll()
        {
            return _employeeContext.Receipts.ToList();
        }

        public Receipt Get(long id)
        {
            return _employeeContext.Receipts.FirstOrDefault(e => e.id == id);
        }

        public int Count(long id)
        {
            return _employeeContext.Receipts.Where(x=> x.id == id).Count();
        }

        public void Add(Receipt entity)
        {
            _employeeContext.Receipts.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(Receipt receipt, Receipt entity)
        {
            receipt.id = receipt.id;
            receipt.provider = entity.provider;
            receipt.currency = entity.currency;
            receipt.commentary = entity.commentary;
            receipt.amount = entity.amount;
            receipt.date = entity.date;
            _employeeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Receipt obj = _employeeContext.Receipts.FirstOrDefault(e => e.id == id);
            _employeeContext.Receipts.Remove(obj);
            _employeeContext.SaveChanges();
        }

        public ResponseAPI Validate(Receipt receipt) {
            ResponseAPI response = new ResponseAPI();
            try
            {
                if (receipt.amount <= 0)
                {
                    throw new System.Exception("Incorrect amount");
                }
                if (string.IsNullOrEmpty(receipt.provider))
                {
                    throw new System.Exception("Incorrect provider");
                }
                if (string.IsNullOrEmpty(receipt.currency))
                {
                    throw new System.Exception("Incorrect currency");
                }
                if (string.IsNullOrEmpty(receipt.commentary))
                {
                    throw new System.Exception("Incorrect commentary");
                }
                if (receipt.date == null)
                {
                    throw new System.Exception("Incorrect date");
                }

                response.Code = 0;
                response.Message = "Succefull";
            }
            catch (System.Exception ex)
            {
                response.Code = System.Net.HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }

            return response;
        }

        public Receipt Get(string param1, string param2)
        {
            throw new System.NotImplementedException();
        }
    }
}
