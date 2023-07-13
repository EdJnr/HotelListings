using AutoMapper;
using HotelListings.Dtos;
using HotelListings.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListings.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork,ILogger<HotelController> logger, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var Hotels = await _unitOfWork.HotelRepository.GetAll();
                var results = _mapper.Map<IList<HotelDTO>>(Hotels);

                return Ok(results);
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in {nameof(GetHotels)} method", error.Message);
                return StatusCode(500, error.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var Hotel = await _unitOfWork.HotelRepository.Get(p=> p.Id==id);
                var result = _mapper.Map<HotelDTO>(Hotel);

                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in {nameof(GetHotel)} method", error.Message);
                return StatusCode(500, error.Message);
            }
        }
    }
}
