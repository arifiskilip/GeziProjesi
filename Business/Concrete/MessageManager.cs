using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Cocnrete;
using System;
using System.Collections.Generic;

namespace Business.Cocnrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResult Add(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Message message)
        {
            _messageDal.Delete(message);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Message>> GetAll()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAllInclude());  
        }

        public IDataResult<Message> GetById(int id)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(x=> x.Id==id));
        }

        public IResult Update(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult(Messages.SuccessfullyModified);
        }
    }
}
