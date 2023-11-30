using AirMetR.DAL;
using AirMetR.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirMetR.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ILogger<ReservationController> _logger;

        // Constructor
        public ReservationController(IReservationRepository reservationRepository, ILogger<ReservationController> logger)
        {
            _reservationRepository = reservationRepository;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> ListReservations(int id)
        {
            // Get reservations based on Property id
            var reservations = await _reservationRepository.GetReservationsByPropertyId(id) ?? new List<Reservation>();
            if (reservations == null)
            {
                _logger.LogError("[HomeController] property list not found while executing _propertyRepository.GetAll()");
            }
            // If there is no reservation, it will return empty table
            Customer? customerInfo = null;


            if (reservations != null)
            {
                foreach (var reservation in reservations)
                {
                    customerInfo = await _reservationRepository.GetCustomerByReservationId(reservation.ReservationId);  // Fetch customer info if user is logged in
                }
            }
            // Return both properties and customer information as JSON
            var result = new
            {
                CustomerInfo = customerInfo,
                Reservations = reservations
            };
            // Return the list of reservations as JSON
            return Ok(result);
        }


        // GET api/values/5
        // View details of a reservation
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            Customer? customer = await _reservationRepository.GetCustomerByReservationId(id);
            var reservation = await _reservationRepository.GetReservationById(id);
            if (reservation == null)
            {
                _logger.LogWarning("[ReservationController] reservation not found while executing _reservationRepository.GetReservationById()", id);
                return NotFound("Reservation not found!");
            }
            // Return both properties and customer information as JSON
            var result = new
            {
                Customer = customer,
                Reservation = reservation
            };
            // Return the list of reservations as JSON
            return Ok(result);
        }


        // POST api/values
        [HttpPost("{id}")]
        public async Task<IActionResult> CompleteReservation(int id, [FromForm] Reservation reservationDetails)
        {
            try
            {
                // Use the provided reservation details
                var reservationDate = reservationDetails.StartDate;
                var endReservationDate = reservationDetails.EndDate;
                var numberOfGuests = reservationDetails.NumberOfGuests;

                // Use a hardcoded or fetched user ID
                var userId = "2"; // Hardcoded for example
                var customer = await _reservationRepository.Customer(userId);
                if (customer == null)
                {
                    _logger.LogError("[ReservationController] Property not found for the PropertyId {PropertyId}", id);
                    return NotFound("Property not found for the PropertyId");
                }

                var property = await _reservationRepository.GetPropertyById(id);
                if (property == null)
                {
                    _logger.LogError("[ReservationController] Property not found for the PropertyId {PropertyId}", id);
                    return NotFound("Property not found for the PropertyId");
                }

                if (numberOfGuests > property.Guest)
                {
                    return BadRequest("The number of guests is more than available.");
                }

                var existingReservations = await _reservationRepository.GetReservationsByPropertyId(id);
                if (existingReservations != null)
                {
                    foreach (var res in existingReservations)
                    {
                        if ((reservationDate <= res.EndDate && endReservationDate >= res.StartDate))
                        {
                            return BadRequest("The chosen date is unavailable for this property, please choose another date!");
                        }
                    }
                }

                // Create and save a reservation
                var reservation = new Reservation
                {
                    Customer = customer,
                    PropertyId = id,
                    StartDate = reservationDate,
                    EndDate = endReservationDate,
                    NumberOfGuests = numberOfGuests,
                    TotalDays = (endReservationDate - reservationDate).Days,
                    TotalPrice = property.Price * (endReservationDate - reservationDate).Days
                };

                var result = await _reservationRepository.Add(reservation);
                if (!result)
                {
                    return BadRequest("Failed to create reservation.");
                }

                return Ok(new { Message = "Reservation successfully created.", reservation.ReservationId });
            }
            catch
            {
                var errors = ModelState.SelectMany(x => x.Value?.Errors?.Select(p => p.ErrorMessage) ?? Enumerable.Empty<string>()).ToList();
                _logger.LogWarning("[ReservationController] Model State is not valid. Errors: {@errors}", errors);
                return BadRequest("Reservation creation failed.");
            }
        }

        // View user's own reservations
        [HttpGet]
        public async Task<IActionResult> Reservation()
        {
            var userId = "2";
            Customer? customer = await _reservationRepository.Customer(userId);
            if (customer == null)
            {
                _logger.LogWarning("[ReservationController] Customer info not found");
                return NotFound("Customer Not found");
            }
            // Retrieve the user's reservations
            var reservations = await _reservationRepository.GetReservationsByUserId(userId);

            // Return both properties and customer information as JSON
            var result = new
            {
                CustomerInfo = customer,
                Reservations = reservations,
            };
            // Return the list of reservations as JSON
            return Ok(result);
        }

        // Get unavailable dates for a property
        [HttpGet("{id}")]
        public async Task<JsonResult> GetUnavailableDates(int id)
        {
            var reservations = await _reservationRepository.GetReservationsByPropertyId(id);
            if (reservations != null)
            {
                var unavailableDates = reservations.SelectMany(r => Enumerable.Range(0, (r.EndDate - r.StartDate).Days + 1).Select(offset => r.StartDate.AddDays(offset).ToString("yyyy-MM-dd"))).ToList();
                _logger.LogInformation("[ReservationController] UnavailableDates: {@unavailableDates}", unavailableDates);
                return Json(new { UnavailableDates = unavailableDates });
            }
            else
            {
                return Json(new { UnavailableDates = Array.Empty<string>() });
            }
        }

        // Update a reservation
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromForm] Reservation reservation)
        {
            try
            {
                // Fetch the reservation from the database using the user id and property id
                var reservationFromDb = await _reservationRepository.GetReservationById(id);
                if (reservationFromDb == null)
                {
                    _logger.LogWarning("[ReservationController] reservation not found while executing _reservationRepository.GetReservationById(). ReservationId: {@id}", id);
                    return NotFound("Reservation not found!");
                }


                // Update the reservation fields
                reservationFromDb.StartDate = reservation.StartDate;
                reservationFromDb.EndDate = reservation.EndDate;
                reservationFromDb.NumberOfGuests = reservation.NumberOfGuests;

                // Calculate the total days and price for the reservation
                reservationFromDb.TotalDays = reservation.TotalDays;
                reservationFromDb.TotalPrice = reservation.TotalPrice;


                var result = await _reservationRepository.Update(reservationFromDb);
                if (result)
                {
                    return Ok(new { Message = "Reservation updated successfully." });
                }
                else
                {
                    _logger.LogWarning("[ReservationController] Reservation update failed for id {id}", id);
                    return BadRequest("Failed to update reservation.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("[ReservationController] Error updating reservation: {Error}", e.Message);
                return BadRequest("Failed to update reservation.");
            }
        }


        // Delete a reservation (Replaced with HttpDelete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                var reservation = await _reservationRepository.GetReservationById(id);
                if (reservation == null)
                {
                    _logger.LogError("[ReservationController] Reservation not found for the ReservationId {ReservationId}", id);
                    return NotFound(new { Message = $"Reservation not found for the ReservationId {id}" });
                }

                bool returnOk = await _reservationRepository.Delete(id);
                if (!returnOk)
                {
                    _logger.LogError("[ReservationController] Reservation deletion failed for the ReservationId {ReservationId}", id);
                    return BadRequest(new { Message = "Reservation deletion failed" });
                }

                return Ok(new { Message = "Reservation deleted successfully." });
            }
            catch (Exception e)
            {
                _logger.LogError("[ReservationController] Error deleting reservation: {Error}", e.Message);
                return BadRequest(new { Message = "Error occurred while deleting reservation." });
            }
        }

    }
}

