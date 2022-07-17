using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.Models.DatabaseModels;
using DirectoryApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryApp.CrudService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MemberContactController : ControllerBase {

        private readonly IRepository<MemberContact> _memberContactRepository;

        public MemberContactController(IRepository<MemberContact> memberContactRepository) {
            _memberContactRepository = memberContactRepository;
        }

        [HttpPost]
        [Route("updcontact")]
        public async Task<IActionResult> UpdateMemberContact([FromBody] UpdateContactRequest updateContactRequest) {
            
            await _memberContactRepository.Update(new MemberContact {
                Content = updateContactRequest.Content,
                Email = updateContactRequest.Email,
                Location = updateContactRequest.Location,
                PhoneNumber = updateContactRequest.PhoneNumber,
                MemberId = updateContactRequest.MemberId
            });

            await _memberContactRepository.SaveChanges();

            return Ok();
        }

    }
}
