using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using System.Collections.Generic;

namespace Business.Cocnrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IResult Add(Contact contact)
        {
            //var result = BusinessRules.Run();
            //if (result!=null)
            //{
            //    return result;
            //}
            _contactDal.Add(contact);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Contact contact)
        {
            _contactDal.Delete(contact);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Contact>> GetAll()
        {
            var data = _contactDal.GetAll();
            return new SuccessDataResult<List<Contact>>(data);
        }

        public IDataResult<Contact> GetById(int id)
        {
            var data = _contactDal.Get(x => x.Id == id);
            return new SuccessDataResult<Contact>(data);
        }

        public IResult Update(Contact contact)
        {
            _contactDal.Update(contact);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
