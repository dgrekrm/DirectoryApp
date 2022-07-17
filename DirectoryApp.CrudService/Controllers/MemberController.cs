using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.Models.DatabaseModels;
using DirectoryApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryApp.CrudService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase {

        private readonly IRepository<Member> _memberRepository;

        public MemberController(IRepository<Member> memberRepository) {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public IActionResult Get() {
            var members = _memberRepository.GetAll();
            return Ok(members);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateMemberRequest createMemberRequest) {

            try {
                await _memberRepository.Create(new Member {
                    Company = createMemberRequest.Company,
                    FullName = createMemberRequest.FullName
                });

                return Ok();
            } catch(Exception ex) {
                return Ok(ex.ToString());
            }
        }

    }
}
