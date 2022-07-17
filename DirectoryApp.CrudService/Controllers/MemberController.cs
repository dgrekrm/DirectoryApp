using DirectoryApp.DataAccessLayer.Repositories;
using DirectoryApp.Models.DatabaseModels;
using DirectoryApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryApp.CrudService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase {

        private readonly MemberRepository _memberRepository;

        public MemberController(MemberRepository memberRepository) {
            _memberRepository = memberRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMemberRequest createMemberRequest) {
            
            await _memberRepository.Create(new Member {
                Company = createMemberRequest.Company,
                FullName = createMemberRequest.FullName
            });

            return Ok();
        }

    }
}
