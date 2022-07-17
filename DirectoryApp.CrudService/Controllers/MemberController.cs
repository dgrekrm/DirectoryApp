using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.Models.DatabaseModels;
using DirectoryApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryApp.CrudService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase {

        private readonly IRepository<MemberContact> _memberContactRepository;

        public MemberController(IRepository<MemberContact> memberContactRepository) {
            _memberContactRepository = memberContactRepository;
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

    }
}
