using Infrastructur.Entities;
using Infrastructur.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public CompanyEntity CreateCompany(string companyName)
        {
            var companyEntity = _companyRepository.Get(x => x.CompanyName == companyName);
            companyEntity ??= _companyRepository.Create(new CompanyEntity { CompanyName = companyName });

            return companyEntity;
        }

        public CompanyEntity Getcompany(string companyName)
        {
            var companyEntity = _companyRepository.Get(x => x.CompanyName == companyName);
            return companyEntity;
        }

        public CompanyEntity GetcompanyById(int id)
        {
            var companyEntity = _companyRepository.Get(x => x.Id == id);
            return companyEntity;
        }

        public IEnumerable<CompanyEntity> GetCompanies()
        {
            var companies = _companyRepository.GetAll();
            return companies;
        }

        public CompanyEntity UpdateCompany(CompanyEntity companyEntity)
        {
            var updatedcompanyEntity = _companyRepository.Update(x => x.Id == companyEntity.Id, companyEntity);
            return updatedcompanyEntity;
        }


        public void DeleteCompany(int id)
        {
            _companyRepository.Delete(x => x.Id == id);
        }
    }
}
