using AutoMapper;
using HotelListings.Dtos;
using HotelListings.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListings.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.CountryRepository.GetAll();
                var results = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(results);
            }
            catch (Exception error)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCountries)} method.{error.Message}");
                return StatusCode(500, error.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCountry(int Id)
        {
            try
            {
                var country = await _unitOfWork.CountryRepository.Get(q=>q.Id==Id);
                var result = _mapper.Map<CountryDTO>(country);
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCountry)} method.{error.Message}");
                return StatusCode(500, error.Message);
            }
        }
    }
}
