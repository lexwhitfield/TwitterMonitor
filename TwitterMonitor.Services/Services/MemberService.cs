using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService()
        {
            _memberRepository = new MemberRepository();
        }

        public async Task<IEnumerable<MemberViewModel>> GetAll(string name, int? partyId, string constituencyName)
        {
            try
            {
                var members = await _memberRepository.GetAll(name, partyId, constituencyName);
                var viewModels = members.Select(ModelTransformer.MemberToMemberViewModel);
                return viewModels;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
