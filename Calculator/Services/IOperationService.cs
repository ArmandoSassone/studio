using Calculator.Models;
using Calculator.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class ServiceLogic : IOperationRepository
    {
        private readonly IOperationRepository repository;
        Task<IEnumerable<ValidationResult>> SaveAsync(Operation entity)
        {
            var errors = Validate(entity);

            //se c'è un errore qualsiasi, lo ritorno 
            if (errors.Any())
            {
                return Task.FromResult(errors);
            }

            //se l'id di City è null significa che posso procedere a salvare, verrà creato dal repo
            if (entity.Id == null)
            {
                entity.Id = Guid.NewGuid();
                list.Cities.Add(entity);
            }
            else
            {
                //Se found (entity.Id) è null, lancio exception
                var found = list.Cities.SingleOrDefault(x => x.Id == entity.Id);

                if (entity.Id == null) throw new ArgumentNullException(nameof(entity.Id));

                mapper.Map(entity, found);
            }
            return repository.Save();
        }
        public Operation Delete(Operation entity)
        {
            throw new NotImplementedException();
        }

        public IList<Operation> Fetch()
        {
            throw new NotImplementedException();
        }

        public Operation GetOperationById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationResult> Save(Operation entity)
        {
            throw new NotImplementedException();
        }

        public Operation Update(Operation entity)
        {
            throw new NotImplementedException();
        }   
    }
}
