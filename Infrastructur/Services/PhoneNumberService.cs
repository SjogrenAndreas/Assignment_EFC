using Infrastructur.Entities;
using Infrastructur.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Services
{
    internal class PhoneNumberService
    {
        private readonly PhoneNumberRepository _phoneNumberRepository;

        public PhoneNumberService(PhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }

        public PhoneNumberEntity CreatePhoneNumber(string workPhone, string mobilePhone)
        {
            var phoneNumberEntity = _phoneNumberRepository.Get(x => x.WorkPhone == workPhone && x.MobilePhone == mobilePhone);
            phoneNumberEntity ??= _phoneNumberRepository.Create(new PhoneNumberEntity { WorkPhone = workPhone, MobilePhone = mobilePhone });

            return phoneNumberEntity;
        }

        public PhoneNumberEntity GetPhoneNumber(string workPhone, string mobilePhone)
        {
            var phoneNumberEntity = _phoneNumberRepository.Get(x => x.WorkPhone == workPhone && x.MobilePhone == mobilePhone );
            return phoneNumberEntity;
        }

        public PhoneNumberEntity GetPhoneNumberById(int id)
        {
            var phoneNumberEntity = _phoneNumberRepository.Get(x => x.Id == id);
            return phoneNumberEntity;
        }

        public IEnumerable<PhoneNumberEntity> GetPhoneNumberes()
        {
            var phoneNumberes = _phoneNumberRepository.GetAll();
            return phoneNumberes;
        }

        public PhoneNumberEntity UpdatePhoneNumber(PhoneNumberEntity phoneNumberEntity)
        {
            var updatedPhoneNumberEntity = _phoneNumberRepository.Update(x => x.Id == phoneNumberEntity.Id, phoneNumberEntity);
            return updatedPhoneNumberEntity;
        }


        public void DeletePhoneNumber(int id)
        {
            _phoneNumberRepository.Delete(x => x.Id == id);
        }
    }
}
