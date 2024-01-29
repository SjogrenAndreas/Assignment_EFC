using Infrastructur.Entities;
using Infrastructur.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Services
{
    public class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RoleEntity CreateRole(string roleName)
        {
            var roleEntity = _roleRepository.Get(x => x.Role == roleName);
            roleEntity ??= _roleRepository.Create(new RoleEntity { Role = roleName });

            return roleEntity;
        }

        public RoleEntity Getrole(string roleName)
        {
            var roleEntity = _roleRepository.Get(x => x.Role == roleName);
            return roleEntity;
        }

        public RoleEntity GetroleById(int id)
        {
            var roleEntity = _roleRepository.Get(x => x.Id == id);
            return roleEntity;
        }

        public IEnumerable<RoleEntity> GetCompanies()
        {
            var companies = _roleRepository.GetAll();
            return companies;
        }

        public RoleEntity UpdateRole(RoleEntity roleEntity)
        {
            var updatedroleEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
            return updatedroleEntity;
        }


        public void DeleteRole(int id)
        {
            _roleRepository.Delete(x => x.Id == id);
        }
    }
}
