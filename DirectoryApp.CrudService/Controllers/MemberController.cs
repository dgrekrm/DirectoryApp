using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.Models.DatabaseModels;
using DirectoryApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryApp.CrudService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase {

        private readonly IRepository<MemberContact> _memberContactRepository;
        private readonly IRepository<Member> _memberRepository;

        public MemberController(IRepository<MemberContact> memberContactRepository, IRepository<Member> memberRepository) {
            _memberContactRepository = memberContactRepository;
            _memberRepository = memberRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateMemberRequest createMemberRequest) {

            await _memberContactRepository.Create(new MemberContact {
                Content = createMemberRequest.Content,
                Email = createMemberRequest.Email,
                Location = createMemberRequest.Location,
                Member = new Member {
                    Company = createMemberRequest.Company,
                    FullName = createMemberRequest.FullName
                },
                PhoneNumber = createMemberRequest.PhoneNumber
            });

            await _memberContactRepository.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] string memberid) {

            var member = await _memberRepository.Find(memberid);

            member.IsDeleted = true;

            var memberContacts = _memberContactRepository.Get(s => s.MemberId == member.UUID).ToList();

            memberContacts.ForEach(s => s.IsDeleted = true);

            await _memberRepository.SaveChanges();

            return Ok();
        }

    }
}
