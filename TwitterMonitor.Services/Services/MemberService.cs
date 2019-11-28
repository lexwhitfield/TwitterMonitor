using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService()
        {
            _memberRepository = new MemberRepository();
        }

        public async Task<IEnumerable<MemberViewModel>> GetAllMembers(int? id, string name, int? partyId, string constituency, string twitterName)
        {
            var members = await _memberRepository.GetAll(id, name, partyId, constituency, twitterName);
            return members.Select(ModelTransformer.MemberToMemberViewModel);
        }

        public async Task<MemberViewModel> GetMemberById(int id)
        {
            var member = await _memberRepository.GetById(id);
            return ModelTransformer.MemberToMemberViewModel(member);
        }

        public async Task<MemberViewModel> UpdateMember(MemberViewModel memberViewModel)
        {
            var original = await _memberRepository.GetById(memberViewModel.Id.Value);
            var member = ModelTransformer.MemberViewModelToMember(memberViewModel, original);

            await _memberRepository.Update(member.Id, member);

            return ModelTransformer.MemberToMemberViewModel(member);
        }

        public async Task<MemberViewModel> AddMember(MemberViewModel memberViewModel)
        {
            var member = ModelTransformer.MemberViewModelToMember(memberViewModel);

            await _memberRepository.Add(member);

            return ModelTransformer.MemberToMemberViewModel(member);
        }

        public async Task<bool> DeleteMember(int id)
        {
            var success = await _memberRepository.Delete(id);
            return success;
        }
    }
}
