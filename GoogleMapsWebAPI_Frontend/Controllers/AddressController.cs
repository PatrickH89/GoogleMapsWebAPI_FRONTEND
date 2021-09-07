using GoogleMapsWebAPI_Frontend.Interfaces;
using GoogleMapsWebAPI_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleMapsWebAPI_Frontend.Controllers
{
    public class AddressController : Controller
    {
        private IAddressService _addressService;

        public AddressController(IAddressService AddressService)
        {
            _addressService = AddressService;
        }

        // get addresses: ~localhost:44372/Address
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (ModelState.IsValid)
            {
                var apiResonse = await _addressService.GetAddresses();
                if (apiResonse == null)
                {
                    return View("Index", null);
                }
                return View(apiResonse);
            }
            return View("Index");
        }

        // get address: ~localhost:44372/Address/Select
        [HttpPost]
        public async Task<IActionResult> Select([FromForm] int id)
        {
            if (ModelState.IsValid)
            {
                var apiResponse = await _addressService.SelectAddress(id);
                if (apiResponse == null)
                {
                    return View("Index", null);
                }
                return View("Index", new List<AddressAPIModel>() { apiResponse });
            }
            return View("Index");
        }

        // add address: ~localhost:44372/Address/CreateAddress
        [HttpGet]
        public IActionResult CreateAddress()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]AddressFormsModel address)
        {
            if (ModelState.IsValid)
            {
                var success = await _addressService.CreateAddress(address);
                TempData["AddressCreated"] = true;
                return RedirectToAction("Index");
            }
            return View("CreateAddress");
        }

        // update address: ~localhost:44372/Address/UpdateAddress
        [HttpGet]
        public async Task<IActionResult> UpdateAddress([FromQuery]int id)
        {
            var apiResponse = await _addressService.SelectAddressForInputFields(id);
            return View("UpdateAddress", apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm]AddressFormsModel address)
        {
            if (ModelState.IsValid)
            {
                var success = await _addressService.UpdateAddress(address);
                TempData["AddressUpdated"] = true;
                return RedirectToAction("Index");
            }
            return View("UpdateAddress");
        }

        // delete address: ~localhost:44372/Address
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _addressService.DeleteAddress(id);
            return RedirectToAction("Index");
        }
    }
}
