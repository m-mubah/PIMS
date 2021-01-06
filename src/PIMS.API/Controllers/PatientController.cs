using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PIMS.API.Data;
using PIMS.API.Domain.Entities;
using PIMS.API.Domain.Requests;

namespace PIMS.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly PIMSContext _context;
        //private readonly ILogger _logger;

        public PatientController(PIMSContext context)
        {
            _context = context;
            //_logger = logger;
        }

        //TODO: Add validation and auto mapping
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto requestData)
        {
            //TODO: Autogenerate hospital number and registration number

            var patient = new Patient
            {
                RegistrationNumber = requestData.RegistrationNumber,
                HospitalNumber = requestData.HospitalNumber,
                FullName = requestData.FullName,
                Identification = requestData.Identification,
                BirthDate = requestData.BirthDate,
                Sex = requestData.Sex,
                PrimaryContactNumber = requestData.PrimaryContactNumber,
                IslandId = requestData.IslandId
            };

            if (requestData.SecondaryContactNumber != null) patient.SecondaryContactNumber = requestData.SecondaryContactNumber;
            if (requestData.History != null)
            {
                var history = new PatientHistory
                {
                    CancerTreatment = requestData.History.CancerTreatment,
                    Medical = requestData.History.Medical,
                    Surgical = requestData.History.Surgical,
                    Familial = requestData.History.Familial,
                    Other = requestData.History.Other
                };

                patient.History = history;
            }

            _context.Add(patient);
            await _context.SaveChangesAsync();

            return Ok(patient);
        }

    }
}
