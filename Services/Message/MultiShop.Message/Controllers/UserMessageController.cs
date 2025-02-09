using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessageAsync()
        {
            var values = await _userMessageService.GetAllMessageAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj Ekleme Başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMessageAsync(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesah Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj Başarıyla Güncellendi");
        }
        [HttpGet("GetMessageSendbox")]
        public async Task<IActionResult> GetMessageSendbox(string id)
        {
            var value = await _userMessageService.GetSendboxMessageAsync(id);
            return Ok(value);
        }

        [HttpGet("GetMessageInbox")]
        public async Task<IActionResult> GetMessageInbox(string id)
        {
            var value = await _userMessageService.GetInboxMessageAsync(id);
            return Ok(value);
        }

        [HttpGet("GetTotalMessageCountByReceiverID")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverID(string id)
        {
            int values = await _userMessageService.GetTotalMessageCountByReceiverID(id);
            return Ok(values);
        }
        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            int messageCount = await _userMessageService.GetTotalMessageCount();
            return Ok(messageCount);
        }
    }
}
